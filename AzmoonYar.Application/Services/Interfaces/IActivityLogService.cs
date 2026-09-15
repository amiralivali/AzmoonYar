using AzmoonYar.Application.Common;
using AzmoonYar.Application.DTOs.ActivityLog;
using AzmoonYar.Application.Logs.Contracts;

namespace AzmoonYar.Application.Services.Interfaces;

public interface IActivityLogService
{
    Task<PagedResult<ActivityLogDto>> GetAllAsync(GetActivityLogDto request, CancellationToken cancellationToken = default);
    Task AddAsync(ILogData logData, long userId);
}