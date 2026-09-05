using AzmoonYar.Application.DTOs.ActivityLog;
using AzmoonYar.Application.DTOs.Common;
using AzmoonYar.Application.Logs.Contracts;
using AzmoonYar.Application.Logs.Formatters;
using AzmoonYar.Application.Logs.Templates;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Services;

public class ActivityLogService(IActivityLogRepository repository)
{
    public async Task<PagedResult<ActivityLogDto>> GetAllAsync(GetActivityLogDto request,CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync(request.SearchPhase, request.EntityType,
            request.PageNumber, request.PageSize, cancellationToken);
        return ToDto(result);
    }

    public async Task AddAsync(ILogData logData, long userId)
    {
        var template = LogTemplates.All[logData.ActivityLogType];
        
        var message = LogMessageFormatter.Format(template.Message, logData);
        
        var log = new ActivityLog(userId, logData.EntityType, logData.ActivityLogType, template.Title, message);
        await repository.AddAsync(log);
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