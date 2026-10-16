using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record TrueFalseItemCreatedLogData(string Id) : ILogData
{
    public EntityType EntityType => EntityType.TrueFalseItem;
    public ActivityLogType ActivityLogType => ActivityLogType.TrueFalseItemCreated;
}