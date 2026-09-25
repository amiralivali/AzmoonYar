using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Specification.Book;

public record BookQueryFilterSpec(
    long UserId,
    string? SearchPhase,
    Grade? Grade, 
    BookSource? BookSource,
    int PageNumber,
    int PageSize);