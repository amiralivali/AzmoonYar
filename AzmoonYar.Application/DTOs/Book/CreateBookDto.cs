using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;

public record CreateBookDto(string BookName, Grade Grade,BookSource BookSource,List<CreateLessonDto> CreateLessonDtos);