using AzmoonYar.Application.DTOs.Auth;

namespace AzmoonYar.Application.Interfaces;

public interface IGoogleTokenValidator
{
    Task<GoogleUserInfoDto> ValidateAsync(string idToken, CancellationToken cancellationToken = default);
}