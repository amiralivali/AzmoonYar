using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Caching.Constants;

public static class QuestionCacheKeyConstants
{
    public const string All = "question:all";

    public static string ById(long id)
        => $"question:{id}";

    public static string CountByLessonId(long lessonId)
        => $"question:count:lesson:{lessonId}";

    public static string ByType(QuestionType type)
        => $"question:type:{type}";
}