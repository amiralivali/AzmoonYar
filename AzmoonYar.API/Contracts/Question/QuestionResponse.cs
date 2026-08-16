using AzmoonYar.API.Contracts.FillInBlankItem;
using AzmoonYar.API.Contracts.MatchingItem;
using AzmoonYar.API.Contracts.OptionalItem;
using AzmoonYar.API.Contracts.TrueFalseItem;
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
