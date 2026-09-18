using AzmoonYar.Application.DTOs.Auth;

namespace AzmoonYar.Application.Interfaces;

public interface IRefreshTokenService
{
    RefreshTokenValue Create(string? family = null);
    string Hash(string value);
}