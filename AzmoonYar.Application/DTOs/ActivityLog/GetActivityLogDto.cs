using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.DTOs.ActivityLog;

public record GetActivityLogDto(
    string? SearchPhase,
    EntityType? EntityType,
    int PageNumber = 1,
    int PageSize = 5);