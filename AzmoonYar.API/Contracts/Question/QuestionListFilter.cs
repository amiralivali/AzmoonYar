using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record QuestionListFilter(string? SearchPhase,
    long? BookId,
    long? LessonId,
    DifficultyLevel? DifficultyLevel,
    Grade? Grade,
    QuestionType? QuestionType);