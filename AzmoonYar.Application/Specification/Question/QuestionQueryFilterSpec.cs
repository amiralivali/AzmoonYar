using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Specification.Question;

public record QuestionQueryFilterSpec(
    long UserId,
    string? SearchPhase,
    long? BookId,
    long? LessonId,
    DifficultyLevel? DifficultyLevel,
    Grade? Grade,
    QuestionType? QuestionType,
    QuestionStatus? QuestionStatus,
    int PageNumber,
    int PageSize);