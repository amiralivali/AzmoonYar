using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.Book;

public record GetBookDto(
    string? SearchPhase,
    Grade? Grade,
    BookSource? BookSource,
    int PageNumber = 1,
    int PageSize = 8);