using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class ActivityLog
{
    public string? Id { get; private set; }
    public long UserId { get;private set; }
    public ActivityLogType ActivityLogType { get; private set; }
    public string Title { get; private set; } = null!;
    public string Message { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get;private set; }

    private ActivityLog()
    {
    }
    public ActivityLog(long userId, ActivityLogType activityLogType, string title , string message)
    {
        UserId = userId;
        ActivityLogType = activityLogType;
        Title = title;
        Message = message;
        CreatedAt = DateTimeOffset.UtcNow;
    }
}