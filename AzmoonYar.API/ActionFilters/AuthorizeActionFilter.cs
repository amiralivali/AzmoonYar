using AzmoonYar.API.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AzmoonYar.API.ActionFilters;

public class AuthorizeActionFilter:IActionFilter
{
    public AuthorizeActionFilter(IAuthService authService)
    {
        _authService = authService;
    }
    private readonly IAuthService _authService;
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("Guid", out var tokenHeader))
        {
            context.Result = new JsonResult(new { message = "Token is missing." })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
            return;
        }
        string token = tokenHeader.ToString();
        if (!_authService.IsValidGuid(token))
        {
            context.Result = new JsonResult(new { message = "Invalid Token." })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
            return; 
        } 
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}