using AzmoonYar.API.Constants;
using AzmoonYar.API.Contracts.User;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using AzmoonYar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
public class UserController(UserService service):BaseController
{
    [HttpPost(UserUriConstants.Add)]
    public async Task<ActionResult<UserResponse>> Add([FromBody] CreateUserRequest request,CancellationToken cancellationToken)
    {
        var dto = await service.AddAsync(request.ToDto(), cancellationToken);
        return dto.ToResponse();
    }
}