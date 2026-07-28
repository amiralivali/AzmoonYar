using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateMatchingQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    List<UpdateMatchingItemRequest>  MatchingItems) : 
    UpdateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);