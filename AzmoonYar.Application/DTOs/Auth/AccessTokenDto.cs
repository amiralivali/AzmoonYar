namespace AzmoonYar.Application.DTOs.Auth;

public record AccessTokenDto(string Token, DateTimeOffset ExpiresAt);