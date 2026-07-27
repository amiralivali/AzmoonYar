using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record QuestionDto(long QuestionId,
    long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    QuestionType QuestionType,
    DateTimeOffset CreatedAt,
    OptionalItemDto? OptionalItem,
    List<TrueFalseItemDto> TrueFalseItems,
    List<MatchingItemDto> MatchingItems,
    List<FillInBlankItemDto> FillInBlankItems);