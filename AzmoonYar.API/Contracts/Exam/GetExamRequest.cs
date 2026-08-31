using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Exam;

public record GetExamRequest(string? SearchPhrase,
    Grade? Grade,
    long? BookId,
    ExamDifficultyLevel? ExamDifficultyLevel,
    ExamType? ExamType,
    QuestionType? QuestionType,
    int PageNumber = 1,
    int PageSize = 10
);