using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateTrueFalseQuestionRequest(long LessonId,
    string QuestionText,
    string? Picture,
    DifficultyLevel DifficultyLevel,
    List<CreateTrueFalseItemRequest>  TrueFalseItems) : 
    CreateBaseQuestionRequest(LessonId, QuestionText, Picture, DifficultyLevel);