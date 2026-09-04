using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.ActivityLog;

public record GetBookRequest(
    string? SearchPhase,
    Grade? Grade,
    BookSource? BookSource,
    int PageNumber = 1,
    int PageSize = 8);