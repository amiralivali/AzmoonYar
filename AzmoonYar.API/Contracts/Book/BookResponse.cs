using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Book;

public record BookResponse(long Id,string BookName,Grade Grade,string? Picture,BookSource BookSource,DateTimeOffset CreatedAt,List<LessonResponse> Lessons);