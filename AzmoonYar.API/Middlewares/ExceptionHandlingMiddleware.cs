using System.Diagnostics;
using System.Net;
using AzmoonYar.Application.Exceptions;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;
using AzmoonYar.Infrastructure.Exceptions;

namespace AzmoonYar.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, IExceptionLogRepository exceptionLogRepository)
    {
        try
        {
            await next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            logger.LogInformation("Request cancelled by client: {Method} {Path}",
                context.Request.Method, context.Request.Path);

            if (!context.Response.HasStarted)
                context.Response.StatusCode = 499;
        }
        catch (Exception ex)
        {
            var statusCode = ResolveStatusCode(ex);

            if (statusCode == HttpStatusCode.InternalServerError)
                logger.LogError(ex, "Unhandled exception on {Method} {Path}",
                    context.Request.Method, context.Request.Path);
            else
                logger.LogWarning(ex, "Handled {ExceptionType} on {Method} {Path} -> {StatusCode}",
                    ex.GetType().Name, context.Request.Method, context.Request.Path, (int)statusCode);

            await LogExceptionAsync(context, ex, statusCode, exceptionLogRepository);

            if (context.Response.HasStarted)
            {
                logger.LogError("Response already started, cannot write problem response");
                throw;
            }

            await WriteProblemAsync(context, statusCode, ResolveDetail(ex, statusCode));
        }
    }

    private static HttpStatusCode ResolveStatusCode(Exception exception) => exception switch
    {
        EntityNotFoundException or AuthenticationFailedException or LessonNotFoundException or LessonNotFoundInBookException => HttpStatusCode.NotFound,

        OptionalItemAlreadyExistsException
            or DuplicateExceptionError
            or QuestionAlreadyExistException
            or QuestionTypeAlreadyExistException
            or DuplicateLessonNumber => HttpStatusCode.Conflict,

        DescriptiveQuestionWithoutItemException
            or FillInBlankItemOperationNotAllowedException
            or InvalidQuestionType
            or MatchingItemOperationNotAllowedException
            or OptionalItemOperationNotAllowedException
            or ShortAnswerQuestionWithoutItemException
            or TrueFalseItemOperationNotAllowedException
            or NotEnoughQuestionsException
            or InvalidQuestionCount
            or InvalidScoreException => HttpStatusCode.BadRequest,

        UploadPhotoException or DeletePhotoException => HttpStatusCode.BadGateway,

        _ => HttpStatusCode.InternalServerError
    };

    private static string ResolveDetail(Exception exception, HttpStatusCode statusCode) =>
        statusCode == HttpStatusCode.InternalServerError
            ? "An unexpected error occurred."
            : exception.Message;

    private async Task LogExceptionAsync(
        HttpContext context,
        Exception exception,
        HttpStatusCode statusCode,
        IExceptionLogRepository repository)
    {
        try
        {
            var log = ExceptionLog.CreateByException(
                exception,
                (int)statusCode,
                context.Request.Path,
                context.Request.Method);

            await repository.AddAsync(log, context.RequestAborted);
        }
        catch (Exception loggingException)
        {
            logger.LogError(loggingException,
                "Failed to persist exception log to MongoDB for {ExceptionType}",
                exception.GetType().Name);
        }
    }

    private static Task WriteProblemAsync(HttpContext context, HttpStatusCode statusCode, string detail)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)statusCode;

        var problem = new
        {
            status = (int)statusCode,
            title = statusCode.ToString(),
            detail,
            traceId = Activity.Current?.TraceId.ToString() ?? context.TraceIdentifier
        };

        return context.Response.WriteAsJsonAsync(problem);
    }
}