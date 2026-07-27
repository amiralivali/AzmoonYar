using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateFillInBlankQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    List<CreateFillInBlankItemRequest>  FillInBlankItems) : 
    CreateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);