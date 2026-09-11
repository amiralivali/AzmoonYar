using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record CreateQuestionRequest(
    long LessonId,
    string QuestionText,
    IFormFile? Picture,
    DifficultyLevel DifficultyLevel,
    QuestionType QuestionType);
