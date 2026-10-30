using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record FillInBlankItemCreatedLogData(string Id) : ILogData
{
    public EntityType EntityType => EntityType.FillInBlankItem;
    public ActivityLogType ActivityLogType => ActivityLogType.FillInBlankItemCreated;
}