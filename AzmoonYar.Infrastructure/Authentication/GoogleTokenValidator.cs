using AzmoonYar.Application.DTOs.Auth;
using AzmoonYar.Application.Exceptions;
using AzmoonYar.Application.Interfaces;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;

namespace AzmoonYar.Infrastructure.Authentication;

public class GoogleTokenValidator(IConfiguration configuration) : IGoogleTokenValidator
{
    public async Task<GoogleUserInfoDto> ValidateAsync(string idToken, CancellationToken cancellationToken = default)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken,
                new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = [configuration["Google:ClientId"]!]
                });

            if (!payload.EmailVerified)
                throw new AuthenticationFailedException();

            return new GoogleUserInfoDto(payload.Subject,
                payload.Email,
                payload.GivenName ?? "",
                payload.FamilyName ?? "");
        }
        catch (InvalidJwtException)
        {
            throw new AuthenticationFailedException();
        }
    }
}