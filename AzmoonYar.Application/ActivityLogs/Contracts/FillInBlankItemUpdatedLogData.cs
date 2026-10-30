using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record FillInBlankItemUpdatedLogData(string Id) : ILogData
{
    public EntityType EntityType => EntityType.FillInBlankItem;
    public ActivityLogType ActivityLogType => ActivityLogType.FillInBlankItemUpdated;
}