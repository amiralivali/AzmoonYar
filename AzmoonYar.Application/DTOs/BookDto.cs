using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs;

public record BookDto(long Id,string BookName,Grade Grade,string? GradeInfo,DateTimeOffset CreatedAt,List<LessonDto> Lessons);