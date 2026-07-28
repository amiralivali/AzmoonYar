using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record UpdateQuestionDto(
    long LessonId,
    string QuestionText,
    string? Picture,
    QuestionType QuestionType,
    DifficultyLevel DifficultyLevel,
    UpdateOptionalItemDto? OptionalItem = null,
    IReadOnlyList<UpdateTrueFalseItemDto> TrueFalseItems = null!,
    IReadOnlyList<UpdateMatchingItemDto> MatchingItems = null!,
    IReadOnlyList<UpdateFillInBlankItemDto> FillInBlankItems = null!);