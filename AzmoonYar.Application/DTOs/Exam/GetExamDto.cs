using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Exam;

public record GetExamDto(string? SearchPhrase,
    Grade? Grade,
    long? BookId,
    ExamDifficultyLevel? ExamDifficultyLevel,
    ExamType? ExamType,
    QuestionType? QuestionType,
    int PageNumber = 1,
    int PageSize = 10
);