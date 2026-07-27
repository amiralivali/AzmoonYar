using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record CreateQuestionDto(
    long LessonId,
    string QuestionText,
    string? Picture,
    QuestionType QuestionType,
    DifficultyLevel DifficultyLevel,
    CreateOptionalItemDto? OptionalItem = null,
    IReadOnlyList<CreateTrueFalseItemDto> TrueFalseItems = null!,
    IReadOnlyList<CreateMatchingItemDto> MatchingItems = null!,
    IReadOnlyList<CreateFillInBlankItemDto> FillInBlankItems = null!);
