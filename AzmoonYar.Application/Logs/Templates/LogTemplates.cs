using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Templates;

public static class LogTemplates
{
    public static readonly IReadOnlyDictionary<ActivityLogType, LogTemplate> All =
        new Dictionary<ActivityLogType, LogTemplate>()
        {
            [ActivityLogType.BookCreated] = new LogTemplate(
                "ایجاد کتاب",
                "کتاب {BookName} ایجاد شد.")
        };
}