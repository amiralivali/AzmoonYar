using AzmoonYar.Application.Common;
using AzmoonYar.Application.Specification.ActivityLog;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.ValueObject;

namespace AzmoonYar.Application.Repositories;

public interface IActivityLogRepository
{
    Task<PagedResult<ActivityLog>> GetAllAsync(ActivityLogQueryFilterSpec queryFilterSpec,
        CancellationToken cancellationToken = default);
    Task<List<ActivityLog>> GetRecent(CancellationToken cancellationToken = default);
    Task<ActivityLog> GetByIdAsync(string id,CancellationToken cancellationToken = default);
    Task AddAsync(ActivityLog activityLog,CancellationToken cancellationToken = default);
}