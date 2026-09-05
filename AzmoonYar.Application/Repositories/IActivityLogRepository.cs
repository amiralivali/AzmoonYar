using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Repositories;

public interface IActivityLogRepository
{
    Task<PagedResult<ActivityLog>> GetAllAsync(string? searchPhase,
        EntityType? entityType,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);
    Task<List<ActivityLog>> GetRecent(CancellationToken cancellationToken = default);
    Task<ActivityLog> GetByIdAsync(string id,CancellationToken cancellationToken = default);
    Task AddAsync(ActivityLog activityLog,CancellationToken cancellationToken = default);
}