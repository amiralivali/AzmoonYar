using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public record BookDeletedLogData(string BookName, string Grade) : ILogData
{
    public EntityType EntityType => EntityType.Book;
    public ActivityLogType ActivityLogType => ActivityLogType.BookDeleted;
}