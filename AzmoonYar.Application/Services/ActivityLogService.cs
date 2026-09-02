using AzmoonYar.Application.Logs.Contracts;
using AzmoonYar.Application.Logs.Formatters;
using AzmoonYar.Application.Logs.Templates;
using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;

namespace AzmoonYar.Application.Services;

public class ActivityLogService(IActivityLogRepository repository)
{
    public async Task AddAsync(ILogData logData, long userId)
    {
        var template = LogTemplates.All[logData.ActivityLogType];
        
        var message = LogMessageFormatter.Format(template.Message, logData);
        
        var log = new ActivityLog(userId, logData.ActivityLogType, template.Title, message);
        await repository.AddAsync(log);
    }
}