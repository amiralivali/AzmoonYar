using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record UpdateFillInBlankQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    List<UpdateFillInBlankItemRequest>  FillInBlankItems) : 
    UpdateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);