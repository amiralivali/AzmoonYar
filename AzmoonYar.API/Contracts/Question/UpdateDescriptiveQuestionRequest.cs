using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateDescriptiveQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel) : 
    UpdateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);