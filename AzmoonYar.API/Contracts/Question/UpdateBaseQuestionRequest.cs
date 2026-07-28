using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateBaseQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel);