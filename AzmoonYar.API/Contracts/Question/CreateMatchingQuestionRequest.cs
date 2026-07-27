using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateMatchingQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    List<CreateMatchingItemRequest> MatchingItems) : 
    CreateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);