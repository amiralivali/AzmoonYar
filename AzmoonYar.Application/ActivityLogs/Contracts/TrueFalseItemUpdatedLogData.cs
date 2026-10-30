using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record TrueFalseItemUpdatedLogData(string Id) : ILogData
{
    public EntityType EntityType => EntityType.TrueFalseItem;
    public ActivityLogType ActivityLogType => ActivityLogType.TrueFalseItemUpdated;
}