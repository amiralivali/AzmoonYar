using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AzmoonYar.Application.DTOs.Auth;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AzmoonYar.Infrastructure.Authentication;

public class JwtTokenService(IOptionsSnapshot<JwtSetting> options) : ITokenService
{
    public AccessTokenDto CreateAccessToken(User user)
    {
        var setting = options.Value;
        var now = DateTimeOffset.UtcNow;
        var expired = now.AddMinutes(setting.AccessTokenMinutes);
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new (JwtRegisteredClaimNames.Iat,
                EpochTime.GetIntDate(now.UtcDateTime).ToString(CultureInfo.InvariantCulture),
                ClaimValueTypes.Integer64),
            new (JwtRegisteredClaimNames.GivenName,user.FirstName),
            new (JwtRegisteredClaimNames.FamilyName,user.LastName),
            new (JwtRegisteredClaimNames.PhoneNumber,user.PhoneNumber)
        };
        
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.Key));
        var token = new JwtSecurityToken(
            issuer: setting.Issuer,
            audience: setting.Audience,
            claims: claims,
            notBefore: now.UtcDateTime,
            expires: expired.UtcDateTime,
            signingCredentials: new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256));
        
        return new AccessTokenDto(new JwtSecurityTokenHandler().WriteToken(token), expired);
    }
}