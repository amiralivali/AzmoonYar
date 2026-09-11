using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;
public record CreateBookDto(string BookName,
    Grade Grade,
    Stream? CoverImageStream,
    string? CoverImageFileName,
    string? CoverImageContentType,
    List<CreateLessonDto> CreateLessonDtos);