using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/")]
public class BaseController : ControllerBase
{
    
}