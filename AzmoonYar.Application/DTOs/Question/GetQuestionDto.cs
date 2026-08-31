using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record GetQuestionDto(
    string? SearchPhase,
    long? BookId,
    long? LessonId,
    DifficultyLevel? DifficultyLevel,
    Grade? Grade,
    QuestionType? QuestionType,
    int PageNumber = 1,
    int PageSize = 10);