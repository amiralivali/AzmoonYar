using AzmoonYar.API.Dtos;
using AzmoonYar.API.Intefaces;
using AzmoonYar.API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    private readonly IAuthService _authService;
    [HttpPost]
    public IActionResult Register(UserDto dto)
    {
        var entity = dto.MapToUser();
       bool check =  _authService.Register(entity);
        if(check)
            return Ok();
        else
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public IActionResult Login(UserDto dto)
    {
        var entity = dto.MapToUser();
        var guid = _authService.Login(entity);
        if (guid!=Guid.Empty)
        {
            return Ok(guid);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult IsValidGuid(string guid)
    {
        bool check = _authService.IsValidGuid(guid);
        if (check)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
}