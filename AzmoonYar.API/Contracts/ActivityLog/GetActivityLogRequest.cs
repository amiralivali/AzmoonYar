using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.ActivityLog;

public record GetActivityLogRequest(
    string? SearchPhase,
    EntityType? EntityType,
    int PageNumber = 1,
    int PageSize = 5);