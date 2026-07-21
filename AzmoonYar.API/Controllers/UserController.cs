using AzmoonYar.API.Contracts.User;
using AzmoonYar.API.Mappers;
using AzmoonYar.Application.Services;
using AzmoonYar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController(UserService service):ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserResponse>> AddAsync([FromBody] CreateUserRequest request,CancellationToken cancellationToken)
    {
        var dto = await service.AddAsync(request.ToDto(), cancellationToken);
        return dto.ToResponse();
    }
}