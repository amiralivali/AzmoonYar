using AzmoonYar.API.Intefaces;

namespace AzmoonYar.API.Middlewear;

public class AuthorizeMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IAuthService authService)
    {
        var path = httpContext.Request.Path.Value;
        if (path!.StartsWith("/swagger") || path.StartsWith("/favicon.ico"))
        {
            await _next(httpContext);
            return;
        }
        string? actionName = httpContext.Request.RouteValues["action"]?.ToString();
        if (actionName == "Login" || actionName == "Register")
        {
            await _next(httpContext);
            return;
        }
        if (!httpContext.Request.Headers.TryGetValue("Guid", out var tokenHeader))
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Token is missing.");
            return;
        }
        if (!authService.IsValidGuid(tokenHeader.ToString()))
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Invalid Token.");
            return;
        }
        await _next(httpContext);
    }
}
