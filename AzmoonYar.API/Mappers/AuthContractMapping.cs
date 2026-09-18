using AzmoonYar.API.Contracts.Auth;
using AzmoonYar.Application.DTOs.Auth;

namespace AzmoonYar.API.Mappers;

public static class AuthContractMapping
{
    public static AuthenticationResponse ToResponse(this AuthenticationDto dto)
       => new(dto.AccessToken,dto.AccessTokenExpireTime,dto.RefreshToken,dto.RefreshTokenExpireTime,dto.User.ToResponse());
}