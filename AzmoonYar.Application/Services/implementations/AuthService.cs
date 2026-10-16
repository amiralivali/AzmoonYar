using AzmoonYar.Application.DTOs.Auth;
using AzmoonYar.Application.DTOs.User;
using AzmoonYar.Application.Exceptions;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services.Interfaces;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Services.implementations;

public class AuthService(IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IRefreshTokenService refreshTokenService,
    IRefreshTokenRepository refreshTokenRepository,
    ITokenService tokenService,
    IGoogleTokenValidator googleTokenValidator) : IAuthService
{
    public async Task<UserDto> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        var duplicateMobile = await userRepository.CheckPhoneNumberDuplicate(dto.PhoneNumber, cancellationToken);
        if (duplicateMobile)
            throw new DuplicateExceptionError(nameof(dto.PhoneNumber));
        if (!string.IsNullOrEmpty(dto.Email))
        {
            var duplicateEmail = await userRepository.CheckEmailDuplicate(dto.Email, cancellationToken);
            if (duplicateEmail)
                throw new DuplicateExceptionError(nameof(dto.Email));
        }
        
        var hashedPassword = passwordHasher.Hash(dto.Password);
        var user = new User(dto.FirstName, dto.LastName, dto.PhoneNumber, hashedPassword);
        user.SetEmail(dto.Email);
        
        await userRepository.AddAsync(user, cancellationToken);
        await userRepository.SaveChangesAsync(cancellationToken);
        return ToDto(user);
    }

    public async Task<AuthenticationDto> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByLoginAsync(requestDto.Login, cancellationToken);
        if (user is null || user.PasswordHash is null ||
            !passwordHasher.Verify(requestDto.Password, user.PasswordHash))
            throw new AuthenticationFailedException();
        
        return await CreateSessionAsync(user, cancellationToken);
    }
    public async Task<AuthenticationDto> RefreshAsync(string rawRefreshToken,
        CancellationToken cancellationToken = default)
    {
        var tokenHash = refreshTokenService.Hash(rawRefreshToken);
        var currentToken = await refreshTokenRepository.GetByHashWithUserAsync(
            tokenHash, cancellationToken);

        if (currentToken is null)
            throw new InvalidRefreshTokenException();

        if (currentToken.RevokedAt is not null)
        {
            await RevokeFamilyAsync(currentToken.Family, cancellationToken);
            throw new InvalidRefreshTokenException();
        }

        if (!currentToken.IsActive)
        {
            currentToken.Revoke();
            await refreshTokenRepository.SaveChangesAsync(cancellationToken);
            throw new InvalidRefreshTokenException();
        }

        var value = refreshTokenService.Create(currentToken.Family);
        var replacement = new RefreshToken(
            currentToken.UserId,
            value.Hash,
            value.Family,
            value.ExpiresAt);

        await refreshTokenRepository.AddAsync(replacement, cancellationToken);
        await refreshTokenRepository.SaveChangesAsync(cancellationToken);

        currentToken.Revoke(replacement.Id);
        await refreshTokenRepository.SaveChangesAsync(cancellationToken);

        return CreateResponse(currentToken.User, value);
    }

    public async Task LogoutAsync(long userId, LogoutRequestDto requestDto, CancellationToken cancellationToken)
    {
        var token = await refreshTokenRepository.GetByHashWithUserAsync(refreshTokenService.Hash(requestDto.RefreshToken),
            cancellationToken);

        if (token is null || token.UserId != userId)
        {
            return;
        }
        token.Revoke();
        await refreshTokenRepository.SaveChangesAsync(cancellationToken);
    }

    private async Task<AuthenticationDto> CreateSessionAsync(User user,CancellationToken cancellationToken = default)
    {
        var refreshTokenValue = refreshTokenService.Create();
        
        var refreshToken = new RefreshToken(user.Id,
            refreshTokenValue.Hash,
            refreshTokenValue.Family,
            refreshTokenValue.ExpiresAt);
        await refreshTokenRepository.AddAsync(refreshToken, cancellationToken);
        await refreshTokenRepository.SaveChangesAsync(cancellationToken);
        return CreateResponse(user,refreshTokenValue);
    }

    private AuthenticationDto CreateResponse(User user, RefreshTokenValue refreshToken)
    {
        var accessToken = tokenService.CreateAccessToken(user);
        return new AuthenticationDto(accessToken.Token,
            accessToken.ExpiresAt,
            refreshToken.Token,
            refreshToken.ExpiresAt,
            ToDto(user));
    }
    
    public async Task<AuthenticationDto> GoogleLoginAsync(GoogleLoginDto dto, CancellationToken cancellationToken)
    {
        var info = await googleTokenValidator.ValidateAsync(dto.IdToken, cancellationToken);

        var user = await userRepository.GetByGoogleIdAsync(info.Subject, cancellationToken)
                   ?? await userRepository.GetByEmailAsync(info.Email, cancellationToken);

        if (user is null)
        {
            user = User.CreateFromGoogle(info.FirstName, info.LastName, info.Email, info.Subject);
            await userRepository.AddAsync(user, cancellationToken);
        }
        else if (user.GoogleId is null)
        {
            user.LinkGoogle(info.Subject);
        }

        await userRepository.SaveChangesAsync(cancellationToken);
        return await CreateSessionAsync(user, cancellationToken);
    }
    
    private async Task RevokeFamilyAsync(string family, CancellationToken cancellationToken)
    {
        var tokens = await refreshTokenRepository.GetActiveByFamilyAsync(family, cancellationToken);
        foreach (var token in tokens)
            token.Revoke();

        await refreshTokenRepository.SaveChangesAsync(cancellationToken);
    }
    
    
    private static UserDto ToDto(User user) => new(
        user.Id,
        user.FirstName,
        user.LastName,
        user.PhoneNumber,
        user.CreatedAt);
}