using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Specification.Exam;

public record ExamQueryFilterSpec(string? SearchPhrase,
    Grade? Grade,
    long? BookId,
    ExamDifficultyLevel? ExamDifficultyLevel,
    ExamType? ExamType,
    QuestionType? QuestionType,
    int PageNumber,
    int PageSize);