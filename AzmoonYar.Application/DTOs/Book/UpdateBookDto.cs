using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;

public record UpdateBookDto(string BookName, Grade Grade,BookSource BookSource,List<UpdateLessonDto> UpdateLessonDtos);