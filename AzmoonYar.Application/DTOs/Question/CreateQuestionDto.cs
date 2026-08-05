using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record CreateQuestionDto(
    long LessonId,
    string QuestionText,
    string? Picture,
    QuestionType QuestionType,
    DifficultyLevel DifficultyLevel);
