using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;

public record UpdateBookDto(string BookName,
    Grade Grade,
    Stream? CoverImageStream,
    string? CoverImageFileName,
    string? CoverImageContentType,
    List<UpdateLessonDto> UpdateLessonDtos);