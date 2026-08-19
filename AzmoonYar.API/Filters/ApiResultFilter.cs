using AzmoonYar.API.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AzmoonYar.API.Filters;

public class ApiResultFilter : IAsyncResultFilter
{
   public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        // Check if the result is already an ApiResult (generic or non-generic)
        if (context.Result is ApiResult or ApiResult<object>)
        {
            await next();
            return;
        }

        // Determine status code from the result type
        int statusCode;

        switch (context.Result)
        {
            case OkObjectResult okResult:
                statusCode = StatusCodes.Status200OK;
                WrapObjectResult(okResult, statusCode);
                break;
            case CreatedResult createdResult:
                context.Result = ApiResult<object?>.Created(createdResult.Value, createdResult.Location);
                break;
            case AcceptedResult acceptedResult:
                statusCode = StatusCodes.Status202Accepted;
                WrapObjectResult(acceptedResult, statusCode);
                break;
            case NotFoundResult:
                statusCode = StatusCodes.Status404NotFound;
                context.Result = new ObjectResult(ApiResult.Failed(statusCode,null))
                { StatusCode = statusCode };
                break;
            case NoContentResult:
                context.Result = new ObjectResult(ApiResult.NoContent())
                    { StatusCode = StatusCodes.Status204NoContent };
                break;
            case ObjectResult objectResult:
                statusCode = objectResult.StatusCode ?? context.HttpContext.Response.StatusCode;
                WrapObjectResult(objectResult, statusCode);
                break;
        }

        await next();
    }

    private static void WrapObjectResult(ObjectResult objectResult, int statusCode)
    {
        ApiResult apiResult = statusCode is >= 200 and < 300
            ? statusCode switch
            {
                StatusCodes.Status202Accepted => ApiResult<object?>.Accepted(objectResult.Value),
                _ => ApiResult<object?>.Succeeded(objectResult.Value)
            }
            : ApiResult.Failed(statusCode, objectResult.Value);

        objectResult.Value = apiResult;
        objectResult.StatusCode = statusCode;
    }
}