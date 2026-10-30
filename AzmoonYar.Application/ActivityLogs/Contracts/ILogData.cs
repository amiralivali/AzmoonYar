using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public interface ILogData
{
    public EntityType EntityType { get; }
    public ActivityLogType ActivityLogType { get;}
}