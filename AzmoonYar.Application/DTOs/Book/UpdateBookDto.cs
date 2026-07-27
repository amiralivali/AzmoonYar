using AzmoonYar.Application.DTOs.Lesson;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;

public record UpdateBookDto(string BookName, Grade Grade,string? GradeInfo,List<UpdateLessonDto> UpdateLessonDtos);