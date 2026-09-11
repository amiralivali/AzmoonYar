using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record UpdateQuestionDto(
    long LessonId,
    string QuestionText,
    Stream? CoverImageStream,
    string? CoverImageFileName,
    string? CoverImageContentType,
    QuestionType QuestionType,
    DifficultyLevel DifficultyLevel);
