using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record BookUpdatedLogData(string BookName, string Grade) : ILogData
{
    public ActivityLogType ActivityLogType => ActivityLogType.BookUpdated;
}