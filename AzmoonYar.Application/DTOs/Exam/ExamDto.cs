using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Exam;

public record ExamDto(long Id,
    string Title,
    ExamStatus Status,
    ExamType Type,
    DateTimeOffset CreatedAt);