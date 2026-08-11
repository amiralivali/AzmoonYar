using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record QuestionResponse(
    long Id,
    long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    QuestionType QuestionType,
    DateTimeOffset CreatedAt,
    OptionalItemResponse? OptionalItem,
    List<FillInBlankItemResponse> FillInBlankItems,
    List<FillInBlankAnswerResponse> FillInBlankAnswers,
    List<TrueFalseItemResponse> TrueFalseItems,
    List<MatchingItemResponse> MatchingItems);
