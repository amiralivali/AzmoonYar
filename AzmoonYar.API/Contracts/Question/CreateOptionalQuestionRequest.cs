using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateOptionalQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    CreateOptionalItemRequest OptionalItem) : 
    CreateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);