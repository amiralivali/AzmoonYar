using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Specification.ActivityLog;

public record ActivityLogQueryFilterSpec(string? SearchPhase,
    EntityType? EntityType,
    int PageNumber,
    int PageSize);