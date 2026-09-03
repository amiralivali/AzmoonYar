using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record QuestionDeletedLogData(string QuestionType): ILogData
{
    public ActivityLogType ActivityLogType => ActivityLogType.QuestionDeleted;
}