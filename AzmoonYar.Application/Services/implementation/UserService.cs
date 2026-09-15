using AzmoonYar.Application.DTOs.User;
using AzmoonYar.Application.Exceptions;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services.Interfaces;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services.implementation;

public class UserService(IUserRepository repository,IPasswordHasher passwordHasher) : IUserService
{
    public async Task<UserDto> GetByIdAsync(long userId, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(userId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User), userId);
        return ToDto(user);
    }
    public async Task<UserDto> AddAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        var hashedPassword = passwordHasher.Hash(dto.Password);
        var user = new User(dto.FirstName, dto.LastName, dto.PhoneNumber, hashedPassword);

        var duplicateMobile = await repository.CheckPhoneNumberDuplicate(user.PhoneNumber, cancellationToken);
        if (duplicateMobile)
            throw new DuplicateExceptionError(nameof(user.PhoneNumber));

        if (!string.IsNullOrEmpty(dto.Email))
        {
            user.SetEmail(dto.Email);
            var duplicateEmail = await repository.CheckEmailDuplicate(user.Email!, cancellationToken);
            if (duplicateEmail)
                throw new DuplicateExceptionError(nameof(user.Email));
        }

        await repository.AddAsync(user, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(user);
    }

    public async Task<UserDto> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        var user = await repository.GetByPhoneNumberAsync(requestDto.PhoneNumber, cancellationToken);

        if (user is null)
            throw new UserNotFoundException();

        var isPasswordValid = passwordHasher.Verify(requestDto.Password, user.Password);

        return !isPasswordValid ? throw new UserNotFoundException() : ToDto(user);
    }

    public async Task<UserDto> UpdateAsync(long userId ,UpdateUserDto dto, CancellationToken cancellationToken = default)
    {
        var user = await repository.GetByIdAsync(userId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User), userId);
        user.UpdateUser(dto.FirstName, dto.LastName, dto.PhoneNumber, dto.Password);
        
        var duplicateMobile = await repository.CheckPhoneNumberDuplicate(user.PhoneNumber, cancellationToken, userId);
        if (duplicateMobile)
            throw new DuplicateExceptionError(nameof(user.PhoneNumber));
        
        if (!string.IsNullOrEmpty(dto.Email))
        {
            user.SetEmail(dto.Email);
            var duplicateEmail = await repository.CheckEmailDuplicate(user.Email!, cancellationToken, userId);
            if (duplicateEmail)
                throw new DuplicateExceptionError(nameof(user.Email));
        } 
        
        repository.Update(user);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(user);
    }
    
    private static UserDto ToDto(User user) => new(
        user.Id,
        user.FirstName,
        user.LastName,
        user.PhoneNumber,
        user.CreatedAt);
}