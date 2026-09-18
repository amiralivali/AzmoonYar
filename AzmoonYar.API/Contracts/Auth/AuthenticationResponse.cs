using AzmoonYar.API.Contracts.User;

namespace AzmoonYar.API.Contracts.Auth;

public record AuthenticationResponse(string AccessToken, DateTimeOffset AccessTokenExpireTime, string RefreshToken,
    DateTimeOffset RefreshTokenExpireTime,
    UserResponse User);