namespace AzmoonYar.Domain.Entities;

public class ExceptionLog
{
    public long Id { get; private set; }

    public string Message { get; private set; } = null!;
    public string? StackTrace { get; private set; }
    public string ExceptionType { get; private set; } = null!;
    public string? Source { get; private set; }
    public string? InnerException { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    private ExceptionLog()
    {
    }

    public ExceptionLog(
        string message,
        string exceptionType)
    {
        Message = message;
        ExceptionType = exceptionType;
        CreatedAt = DateTimeOffset.UtcNow;
    }
}