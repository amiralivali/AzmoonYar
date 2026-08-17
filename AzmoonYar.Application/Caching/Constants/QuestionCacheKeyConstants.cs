using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Caching.Constants;

public static class QuestionCacheKeyConstants
{
    public static string All(string? search, long? bookId, long? lessonId,
        DifficultyLevel? difficulty, Grade? grade, QuestionType? type,
        int pageNumber, int pageSize)
        => $"questions:all:{search}:{bookId}:{lessonId}:{difficulty}:{grade}:{type}:{pageNumber}:{pageSize}";
    
    public static string ById(long id)
        => $"question:{id}";

    public static string CountByLessonId(long lessonId)
        => $"question:count:lesson:{lessonId}";
}