using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Exam;

public record ExamResponse(long Id,
    string Title,
    ExamStatus Status,
    ExamType Type,
    DateTimeOffset CreatedAt);