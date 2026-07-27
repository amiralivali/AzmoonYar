using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record QuestionResponse(long QuestionId,
    long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    QuestionType QuestionType,
    DateTimeOffset CreatedAt,
    OptionalItemResponse? OptionalItem,
    List<TrueFalseItemResponse> TrueFalseItems,
    List<MatchingItemResponse> MatchingItems,
    List<FillInBlankItemResponse> FillInBlankItems);