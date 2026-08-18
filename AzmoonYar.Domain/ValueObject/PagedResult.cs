namespace AzmoonYar.Application.DTOs.Common;

public record PagedResult<T>(IReadOnlyList<T> Items,
    int PageNumber,
    int PageSize,
    int TotalCount,
    int TotalPages);