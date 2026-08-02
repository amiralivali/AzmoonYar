using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.CacheKeys;

public static class QuestionKeys
{
    public const string AllQuestions = "question:all";
    public static string ById(long id) => $"question:{id}";
    public static string AllByType(QuestionType type) => $"question:type:{type}";
}