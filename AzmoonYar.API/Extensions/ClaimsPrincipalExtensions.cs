using System.Globalization;
using System.Security.Claims;
using AzmoonYar.Application.Exceptions;
using Microsoft.IdentityModel.JsonWebTokens;

namespace AzmoonYar.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static long GetUserId(this ClaimsPrincipal principal)
    {
        var subject = principal.FindFirstValue(JwtRegisteredClaimNames.Sub);
        return long.TryParse(subject, NumberStyles.None, CultureInfo.InvariantCulture, out var userId)
            ? userId : throw new AuthenticationFailedException();
    }
}