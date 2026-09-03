using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Templates;

public static class LogTemplates
{
    public static readonly IReadOnlyDictionary<ActivityLogType, LogTemplate> All =
        new Dictionary<ActivityLogType, LogTemplate>()
        {
            [ActivityLogType.BookCreated] = new LogTemplate(
                "ایجاد کتاب",
                "کتاب «{BookName}» در مقطع {Grade} ایجاد شد"),
            [ActivityLogType.BookDeleted] = new LogTemplate(
                "حذف کتاب",
                "کتاب «{BookName}» در مقطع {Grade} حذف شد"),
            [ActivityLogType.BookUpdated] = new LogTemplate(
                "ویرایش کتاب",
                "کتاب «{BookName}» در مقطع {Grade} ویرایش شد"),
            [ActivityLogType.QuestionCreated] = new LogTemplate(
                "ایجاد سوال",
                "سوال {QuestionType} جدید اضافه شد"),
            [ActivityLogType.QuestionDeleted] = new LogTemplate(
                "حذف سوال",
                "سوال {QuestionType} حذف شد"),
            [ActivityLogType.QuestionUpdated] = new LogTemplate(
                "ویرایش سوال",
                "سوال {QuestionType} ویرایش شد")
        };
}