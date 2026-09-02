using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Repositories;

public interface IActivityLogRepository
{
    Task<List<ActivityLog>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ActivityLog> GetByIdAsync(string id,CancellationToken cancellationToken = default);
    Task AddAsync(ActivityLog activityLog,CancellationToken cancellationToken = default);
}