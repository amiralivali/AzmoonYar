using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Caching.Constants;

public static class QuestionCacheKeyConstants
{
    public static string ById(long id)
        => $"question:{id}";

    public static string CountByLessonId(long lessonId)
        => $"question:count:lesson:{lessonId}";
}