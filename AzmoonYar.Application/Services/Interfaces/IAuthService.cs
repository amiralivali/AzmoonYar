using AzmoonYar.Application.DTOs.Auth;
using AzmoonYar.Application.DTOs.User;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IAuthService
{
    Task<UserDto> RegisterAsync(CreateUserDto dto, CancellationToken cancellationToken = default);
    Task<AuthenticationDto> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken);
    Task LogoutAsync(long userId,LogoutRequestDto requestDto, CancellationToken cancellationToken);
}