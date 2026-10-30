using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record MatchingItemDeletedLogData(string Id) : ILogData
{
    public EntityType EntityType => EntityType.MatchingItem;
    public ActivityLogType ActivityLogType => ActivityLogType.MatchingItemDeleted;
}