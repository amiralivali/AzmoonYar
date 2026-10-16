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
                "اضافه سوال تستی",
                "آیتم تستی به سوال با شناسه {questionId} اضافه شد"),
            [ActivityLogType.OptionalItemUpdated] = new LogTemplate(
                "ویرایش سوال تستی",
                "آیتم تستی به سوال با شناسه {questionId} ویرایش شد"),
            [ActivityLogType.OptionalItemDeleted] = new LogTemplate(
                "حذف سوال تستی",
                "آیتم تستی به سوال با شناسه {questionId} حذف شد"),
            [ActivityLogType.TrueFalseItemCreated] = new LogTemplate(
                "اضافه سوال صحیح غلط",
                "آیتم صحیح غلط به سوال با شناسه {questionId} اضافه شد"),
            [ActivityLogType.TrueFalseItemUpdated] = new LogTemplate(
                "ویرایش سوال صحیح غلط",
                "آیتم صحیح غلط به سوال با شناسه {questionId} ویرایش شد"),
            [ActivityLogType.TrueFalseItemDeleted] = new LogTemplate(
                "حذف سوال صحیح غلط",
                "آیتم صحیح غلط به سوال با شناسه {questionId} حذف شد"),
            [ActivityLogType.MatchingItemCreated] = new LogTemplate(
                "اضافه سوال وصل کردنی",
                "آیتم وصل کردنی به سوال با شناسه {questionId} اضافه شد"),
            [ActivityLogType.MatchingItemUpdated] = new LogTemplate(
                "ویرایش سوال وصل کردنی",
                "آیتم وصل کردنی به سوال با شناسه {questionId} ویرایش شد"),
            [ActivityLogType.MatchingItemDeleted] = new LogTemplate(
                "حذف سوال وصل کردنی",
                "آیتم وصل کردنی به سوال با شناسه {questionId} حذف شد"),
            [ActivityLogType.FillInBlankItemCreated] = new LogTemplate(
                "اضافه سوال جاخالی",
                "آیتم جاخالی به سوال با شناسه {questionId} اضافه شد"),
            [ActivityLogType.FillInBlankItemUpdated] = new LogTemplate(
                "ویرایش سوال جاخالی",
                "آیتم جاخالی به سوال با شناسه {questionId} ویرایش شد"),
            [ActivityLogType.FillInBlankItemDeleted] = new LogTemplate(
                "حذف سوال جاخالی",
                "آیتم جاخالی به سوال با شناسه {questionId} حذف شد"),
        };
}