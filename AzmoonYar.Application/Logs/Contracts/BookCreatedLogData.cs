using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public sealed record BookCreatedLogData(string BookName) : ILogData
{
    public ActivityLogType ActivityLogType => ActivityLogType.BookCreated ;
}