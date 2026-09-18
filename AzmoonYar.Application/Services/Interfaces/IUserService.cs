using AzmoonYar.Application.DTOs.User;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(long userId, CancellationToken cancellationToken);

    Task<UserDto> UpdateAsync(long userId, UpdateUserDto dto, CancellationToken cancellationToken = default);
}