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
                "سوال {QuestionType} ویرایش شد"),
            [ActivityLogType.OptionalItemCreated] = new LogTemplate(
                "افزودن آیتم تستی",
                "آیتم تستی به سوال با شناسه {Id} اضافه شد"),
            [ActivityLogType.OptionalItemUpdated] = new LogTemplate(
                "ویرایش آیتم تستی",
                "آیتم تستی سوال با شناسه {Id} ویرایش شد"),
            [ActivityLogType.OptionalItemDeleted] = new LogTemplate(
                "حذف آیتم تستی",
                "آیتم تستی از سوال با شناسه {Id} حذف شد"),

            [ActivityLogType.TrueFalseItemCreated] = new LogTemplate(
                "افزودن آیتم صحیح غلط",
                "آیتم صحیح غلط به سوال با شناسه {Id} اضافه شد"),
            [ActivityLogType.TrueFalseItemUpdated] = new LogTemplate(
                "ویرایش آیتم صحیح غلط",
                "آیتم صحیح غلط سوال با شناسه {Id} ویرایش شد"),
            [ActivityLogType.TrueFalseItemDeleted] = new LogTemplate(
                "حذف آیتم صحیح غلط",
                "آیتم صحیح غلط از سوال با شناسه {Id} حذف شد"),

            [ActivityLogType.MatchingItemCreated] = new LogTemplate(
                "افزودن آیتم وصل کردنی",
                "آیتم وصل کردنی به سوال با شناسه {Id} اضافه شد"),
            [ActivityLogType.MatchingItemUpdated] = new LogTemplate(
                "ویرایش آیتم وصل کردنی",
                "آیتم وصل کردنی سوال با شناسه {Id} ویرایش شد"),
            [ActivityLogType.MatchingItemDeleted] = new LogTemplate(
                "حذف آیتم وصل کردنی",
                "آیتم وصل کردنی از سوال با شناسه {Id} حذف شد"),

            [ActivityLogType.FillInBlankItemCreated] = new LogTemplate(
                "افزودن آیتم جاخالی",
                "آیتم جاخالی به سوال با شناسه {Id} اضافه شد"),
            [ActivityLogType.FillInBlankItemUpdated] = new LogTemplate(
                "ویرایش آیتم جاخالی",
                "آیتم جاخالی سوال با شناسه {Id} ویرایش شد"),
            [ActivityLogType.FillInBlankItemDeleted] = new LogTemplate(
                "حذف آیتم جاخالی",
                "آیتم جاخالی از سوال با شناسه {Id} حذف شد"),
        };
}