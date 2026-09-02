using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Logs.Contracts;

public interface ILogData
{
    public ActivityLogType ActivityLogType { get;}
}