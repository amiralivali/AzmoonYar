using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record OptionalItemUpdatedLogData(string Id) : ILogData
{
    public EntityType EntityType => EntityType.OptionalItem;
    public ActivityLogType ActivityLogType => ActivityLogType.OptionalItemUpdated;
}