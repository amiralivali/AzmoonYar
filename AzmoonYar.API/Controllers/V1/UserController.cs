using Asp.Versioning;
using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts;
using AzmoonYar.API.Contracts.User;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers.V1;

[ApiVersion(1.0)]
public class UserController(UserService service) : BaseController
{
    [HttpGet(UserUriConstants.GetById)]
    public async Task<ApiResult<UserResponse>> GetById(long id,CancellationToken cancellationToken)
    {
        var user = await service.GetByIdAsync(id, cancellationToken);
        return user.ToResponse();
    }

    [HttpPost(UserUriConstants.Add)]
    public async Task<ApiResult<UserResponse>> Add([FromBody] CreateUserRequest request,CancellationToken cancellationToken)
    {
        var dto = await service.AddAsync(request.ToDto(), cancellationToken);
        return dto.ToResponse();
    }
    
    [HttpPost(UserUriConstants.Update)]
    public async Task<ApiResult<UserResponse>> Update(long id ,UpdateUserRequest request,CancellationToken cancellationToken)
    {
        var dto = await service.UpdateAsync(id,request.ToDto(), cancellationToken);
        return dto.ToResponse();
    }
}