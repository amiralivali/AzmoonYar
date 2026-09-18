using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.Auth;
using AzmoonYar.API.Contracts.User;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;

[ApiVersion(1.0)]
public class AuthController(IAuthService service) : BaseController
{
    [AllowAnonymous]
    [HttpPost(AuthLogUriConstants.Login)]
    public async Task<ApiResult<AuthenticationResponse>> Login(LoginRequest request,
        CancellationToken cancellationToken)
    {
        var user = await service.LoginAsync(request.ToDto(), cancellationToken);
        return user.ToResponse();
    }
    
    [AllowAnonymous]
    [HttpPost(AuthLogUriConstants.Register)]
    public async Task<ApiResult<AuthenticationResponse>> Register(CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await service.RegisterAsync(request.ToDto(), cancellationToken);
        return user.ToResponse();
    }
}