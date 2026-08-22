using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.User;
using AzmoonYar.Application.Exceptions;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class UserService(IUserRepository repository)
{
    public async Task<UserDto> GetByIdAsync(long userId, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(userId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User), userId);
        return ToDto(user);
    }
    public async Task<UserDto> AddAsync(CreateUserDto dto,CancellationToken cancellationToken = default)
    {
        var user = new User(dto.FirstName,dto.LastName,dto.PhoneNumber,dto.Password);
        
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
        
        await repository.AddAsync(user,cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
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