using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.User;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Services;

public class UserService(IUserRepository repository)
{
    public async Task<UserDto> AddAsync(CreateUserDto dto,CancellationToken cancellationToken = default)
    {
        var user = new User(dto.FirstName, dto.LastName,dto.PhoneNumber);
        if (dto is { UserName: not null, Password: not null })
            user.SetCredentials(dto.UserName, dto.Password);
        await repository.AddAsync(user,cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return ToDto(user);
    }
    
    private static UserDto ToDto(User user) => new(
        user.Id,
        user.FirstName,
        user.LastName,
        user.UserName,
        user.PhoneNumber,
        user.CreatedAt);
}