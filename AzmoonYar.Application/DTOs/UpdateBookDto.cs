using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs;

public record UpdateBookDto(string BookName, Grade Grade,string? GradeInfo,List<UpdateLessonDto> UpdateLessonDtos);