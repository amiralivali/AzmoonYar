using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Book;

public record BookResponse(long Id,string BookName,Grade Grade,BookSource BookSource,DateTimeOffset CreatedAt,List<LessonResponse> Lessons,string? CoverImageUrl);