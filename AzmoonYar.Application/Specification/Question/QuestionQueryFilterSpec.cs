using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Specification.Question;

public record QuestionQueryFilterSpec(string? SearchPhase,
    long? BookId,
    long? LessonId,
    DifficultyLevel? DifficultyLevel,
    Grade? Grade,
    QuestionType? QuestionType,
    int PageNumber,
    int PageSize);