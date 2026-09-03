using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record BookDeletedLogData(string BookName, string Grade) : ILogData
{
    public ActivityLogType ActivityLogType => ActivityLogType.BookDeleted;
}