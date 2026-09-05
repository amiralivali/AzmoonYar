using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;

public record UpdateBookDto(string BookName, Grade Grade,string? Picture,List<UpdateLessonDto> UpdateLessonDtos);