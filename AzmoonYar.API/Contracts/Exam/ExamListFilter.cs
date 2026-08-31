using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Exam;

public record ExamListFilter(string? SearchPhrase,
    Grade? Grade,
    long? BookId,
    ExamDifficultyLevel? ExamDifficultyLevel,
    ExamType? ExamType,
    QuestionType? QuestionType
    );