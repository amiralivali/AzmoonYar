using AzmoonYar.Application.DTOs.Auth;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Interfaces;

public interface ITokenService
{
    AccessTokenDto CreateAccessToken(User user);
}