using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateQuestionRequest(long LessonId, string QuestionText,
    string? Picture,QuestionType QuestionType,
    DifficultyLevel DifficultyLevel);