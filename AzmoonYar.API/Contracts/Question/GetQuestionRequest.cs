using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Question;

public record GetQuestionRequest(
    string? SearchPhase,
    long? BookId,
    long? LessonId,
    DifficultyLevel? DifficultyLevel,
    Grade? Grade,
    QuestionType? QuestionType,
    QuestionStatus? QuestionStatus,
    int PageNumber = 1,
    int PageSize = 10);