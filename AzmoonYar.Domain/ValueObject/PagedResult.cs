namespace AzmoonYar.Domain.ValueObject;

public record PagedResult<T>(IReadOnlyList<T> Items,
    int PageNumber,
    int PageSize,
    int TotalCount,
    int TotalPages);