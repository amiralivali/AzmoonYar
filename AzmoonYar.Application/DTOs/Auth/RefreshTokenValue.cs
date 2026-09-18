namespace AzmoonYar.Application.DTOs.Auth;

public record RefreshTokenValue(string Token,
    string Hash,
    string Family,
    DateTimeOffset ExpiresAt);