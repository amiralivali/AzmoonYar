using AzmoonYar.Application.DTOs.FillInBlankItem;
using AzmoonYar.Application.DTOs.MatchingItem;
using AzmoonYar.Application.DTOs.OptionalItem;
using AzmoonYar.Application.DTOs.TrueFalseItem;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record QuestionDto(
    long QuestionId,
    long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    QuestionType QuestionType,
    DateTimeOffset CreatedAt,
    OptionalItemDto? OptionalItem,
    List<FillInBlankItemDto> FillInBlankItems ,
    List<FillInBlankAnswerDto> FillInBlankAnswers,
    List<TrueFalseItemDto> TrueFalseItems,
    List<MatchingItemDto> MatchingItems);
