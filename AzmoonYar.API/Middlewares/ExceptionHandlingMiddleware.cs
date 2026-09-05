using System.Net;
using AzmoonYar.Application.Exceptions;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionLog> logger)
{
    public async Task InvokeAsync(HttpContext context, IExceptionLogRepository exceptionLogRepository)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var statusCode = ResolveStatusCode(ex);

            await LogExceptionAsync(context, ex, statusCode, exceptionLogRepository);
            await WriteProblemAsync(context, statusCode, ResolveDetail(ex, statusCode));
        }
    }

    private static HttpStatusCode ResolveStatusCode(Exception exception) => exception switch
    {
        EntityNotFoundException or UserNotFoundException or LessonNotFoundException or LessonNotFoundInBookException => HttpStatusCode.NotFound,
        OptionalItemAlreadyExistsException or
            DuplicateExceptionError or QuestionAlreadyExistException
            or QuestionTypeAlreadyExistException=> HttpStatusCode.Conflict,
        DescriptiveQuestionWithoutItemException
            or FillInBlankItemOperationNotAllowedException
            or InvalidQuestionType
            or MatchingItemOperationNotAllowedException
            or OptionalItemOperationNotAllowedException
            or ShortAnswerQuestionWithoutItemException
            or TrueFalseItemOperationNotAllowedException
            or NotEnoughQuestionsException
            or InvalidQuestionCount
            or InvalidQuestionType
            or InvalidScoreException=> HttpStatusCode.BadRequest,
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
            detail
        };

        return context.Response.WriteAsJsonAsync(problem);
    }
}