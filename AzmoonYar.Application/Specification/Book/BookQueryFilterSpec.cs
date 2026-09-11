using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Specification.Book;

public record BookQueryFilterSpec(string? SearchPhase,
    Grade? Grade, 
    BookSource? BookSource,
    int PageNumber,
    int PageSize);