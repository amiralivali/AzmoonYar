using AzmoonYar.Application.DTOs.User;

namespace AzmoonYar.Application.DTOs.Auth;

public record AuthenticationDto(
    string AccessToken,
    DateTimeOffset AccessTokenExpireTime,
    string RefreshToken,
    DateTimeOffset RefreshTokenExpireTime,
    UserDto User);