using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public abstract record CreateBaseQuestionRequest(
    long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel);
