using System.Security.Cryptography;
using System.Text;
using AzmoonYar.Application.DTOs.Auth;
using AzmoonYar.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AzmoonYar.Infrastructure.Authentication;

public class RefreshTokenService(IOptionsSnapshot<JwtSetting> options) : IRefreshTokenService
{
    public RefreshTokenValue Create(string? family = null)
    {
        var rawToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        return new RefreshTokenValue(rawToken,
            Hash(rawToken),
            family ?? Convert.ToHexString(RandomNumberGenerator.GetBytes(32)),
            DateTimeOffset.UtcNow.AddDays(options.Value.RefreshTokenDays));
    }

    public string Hash(string value)
         => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
}