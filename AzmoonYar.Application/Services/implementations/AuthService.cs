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
    ITokenService tokenService) : IAuthService
{
    public async Task<AuthenticationDto> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
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
        return await CreateSessionAsync(user, cancellationToken);
    }

    public async Task<AuthenticationDto> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByLoginAsync(requestDto.Login, cancellationToken);
        if (user is null || !passwordHasher.Verify(requestDto.Password,user.PasswordHash))
            throw new AuthenticationFailedException();
        
        return await CreateSessionAsync(user, cancellationToken);
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
    private static UserDto ToDto(User user) => new(
        user.Id,
        user.FirstName,
        user.LastName,
        user.PhoneNumber,
        user.CreatedAt);
}