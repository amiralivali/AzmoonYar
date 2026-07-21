using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs;

public record CreateBookDto(string BookName, Grade Grade,string? GradeInfo,List<CreateLessonDto> CreateLessonDtos);