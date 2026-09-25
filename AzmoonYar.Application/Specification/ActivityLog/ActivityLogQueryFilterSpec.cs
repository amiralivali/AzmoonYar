using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Specification.ActivityLog;

public record ActivityLogQueryFilterSpec(
    long UserId,
    string? SearchPhase,
    EntityType? EntityType,
    int PageNumber,
    int PageSize);