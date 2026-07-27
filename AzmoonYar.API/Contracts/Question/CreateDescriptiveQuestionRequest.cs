using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateDescriptiveQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel) : 
    CreateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);