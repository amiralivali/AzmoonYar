using AzmoonYar.Application.DTOs.Auth;
using AzmoonYar.Application.DTOs.User;
using AzmoonYar.Application.Exceptions;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services.Interfaces;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services.implementations;

public class UserService(IUserRepository repository,IPasswordHasher passwordHasher) : IUserService
{
    public async Task<UserDto> GetByIdAsync(long userId, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(userId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User), userId);
        return ToDto(user);
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