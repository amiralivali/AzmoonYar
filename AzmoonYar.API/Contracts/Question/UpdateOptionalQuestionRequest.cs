using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateOptionalQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    UpdateOptionalItemRequest OptionalItem) : 
    UpdateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);