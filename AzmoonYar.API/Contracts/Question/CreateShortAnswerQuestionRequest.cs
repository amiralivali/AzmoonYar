using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateShortAnswerQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel) : 
    CreateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);