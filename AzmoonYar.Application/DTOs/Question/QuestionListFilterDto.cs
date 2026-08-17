using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Question;

public record QuestionListFilterDto(string? SearchPhase,
    long? BookId,
    long? LessonId,
    DifficultyLevel? DifficultyLevel,
    Grade? Grade,
    QuestionType? QuestionType);