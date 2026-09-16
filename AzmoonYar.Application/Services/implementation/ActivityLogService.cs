using AzmoonYar.Application.Caching;
using AzmoonYar.Application.Common;
using AzmoonYar.Application.DTOs.ActivityLog;
using AzmoonYar.Application.Logs.Contracts;
using AzmoonYar.Application.Logs.Formatters;
using AzmoonYar.Application.Logs.Templates;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Application.Services.Interfaces;
using AzmoonYar.Application.Specification.ActivityLog;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Services.implementation;

public class ActivityLogService(IActivityLogRepository repository,DashboardCache cache) : IActivityLogService
{
    public async Task<PagedResult<ActivityLogDto>> GetAllAsync(GetActivityLogDto request
        ,CancellationToken cancellationToken = default)
    {
        var queryFilter = new ActivityLogQueryFilterSpec(request.SearchPhase,
            request.EntityType,
            request.PageNumber,
            request.PageSize);
        var result = await repository.GetAllAsync(queryFilter, cancellationToken);
        return ToDto(result);
    }

    public async Task AddAsync(ILogData logData, long userId, CancellationToken cancellationToken)
    {
        var template = LogTemplates.All[logData.ActivityLogType];
        
        var message = LogMessageFormatter.Format(template.Message, logData);
        
        var log = new ActivityLog(userId, logData.EntityType, logData.ActivityLogType, template.Title, message);
        await repository.AddAsync(log,cancellationToken);
        await cache.InvalidateAsync(cancellationToken);
    }
    private static PagedResult<ActivityLogDto> ToDto(PagedResult<ActivityLog> result)
        => new (result.Items.Select(ToDto).ToList(),
            result.PageNumber,
            result.PageSize,
            result.TotalCount,
            result.TotalPages);

    private static ActivityLogDto ToDto(ActivityLog log)
    {
        return new ActivityLogDto(log.Id, log.Message, log.CreatedAt);
    }
    
}