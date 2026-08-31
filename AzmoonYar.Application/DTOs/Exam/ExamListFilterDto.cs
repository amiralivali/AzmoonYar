using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Exam;

public record ExamListFilterDto(string? SearchPhrase,
    Grade? Grade,
    long? BookId,
    ExamDifficultyLevel? ExamDifficultyLevel,
    ExamType? ExamType,
    QuestionType? QuestionType
);