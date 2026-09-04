using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record QuestionUpdatedLogData(string QuestionType): ILogData
{
    public EntityType EntityType => EntityType.Question;
    public ActivityLogType ActivityLogType => ActivityLogType.QuestionUpdated;
}