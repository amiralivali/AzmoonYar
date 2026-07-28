using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateTrueFalseQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    List<UpdateTrueFalseItemRequest>  TrueFalseItems) : 
    UpdateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);