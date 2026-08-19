using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Contracts;

public class ApiResult(bool success,
    int statusCode,
    object? error = null,
    string? location = null) : IActionResult
{
    public bool Success { get; } = success;
    public int StatusCode { get; } = statusCode;
    public object? Error { get; } = error;

    public static ApiResult Succeeded() 
        =>  new (true, StatusCodes.Status200OK);
    
    public static ApiResult Failed(int statusCode,object? error)
        =>  new (false, statusCode,error);
    
    public static ApiResult NoContent()
        => new (true, StatusCodes.Status204NoContent);
    
    public Task ExecuteResultAsync(ActionContext context)
    {
        // Allows the envelope middleware to recognize an ApiResult returned directly
        // by a controller and avoid wrapping it a second time.
        context.HttpContext.Items[typeof(ApiResult)] = true;

        if (location is not null)
            context.HttpContext.Response.Headers.Location = location;

        return new ObjectResult(this)
        {
            StatusCode = StatusCode
        }.ExecuteResultAsync(context);
    }
}

public class ApiResult<T>(T? data,
    bool success,
    int statusCode,
    object? error = null,
    string? location = null) : ApiResult(success, statusCode, error, location)
{
    public T? Data { get; } = data;

    public static ApiResult<T> Succeeded(T? data)
         => new (data, true, StatusCodes.Status200OK);

    public static ApiResult<T> Created(T? data, string? location)
         => new (data, true, StatusCodes.Status201Created, location: location);
    
    public static ApiResult<T> Accepted(T? data)
        => new (data, true, StatusCodes.Status202Accepted);
    
    public static implicit operator ApiResult<T>(T? data) => Succeeded(data);
}