namespace AzmoonYar.Application.DTOs.Exam;

public record ExamHeaderDto(
    string? SchoolName,
    string ExamTitle,
    string? TeacherName,
    string? ClassName,
    DateTimeOffset? ExamDate,
    int DurationMinutes,
    string? LogoPicture);