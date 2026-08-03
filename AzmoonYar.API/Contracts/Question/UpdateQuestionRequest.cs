using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    QuestionType QuestionType,
    UpdateOptionalItemRequest? OptionalItem,
    List<UpdateFillInBlankItemRequest>? FillInBlankItems,
    List<UpdateTrueFalseItemRequest>? TrueFalseItems,
    List<UpdateMatchingItemRequest>? MatchingItems);