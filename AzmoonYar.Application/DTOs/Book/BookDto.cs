using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;

public record BookDto(long Id,string BookName,Grade Grade,BookSource BookSource,DateTimeOffset CreatedAt,List<LessonDto> Lessons);