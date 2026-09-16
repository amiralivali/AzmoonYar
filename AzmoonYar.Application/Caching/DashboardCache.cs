using AzmoonYar.Application.Caching.Constants;
using AzmoonYar.Application.DTOs.Dashboard;
using AzmoonYar.Application.Interfaces;

namespace AzmoonYar.Application.Caching;

public class DashboardCache(ICacheService service)
{
    private static readonly TimeSpan CachedExpiration = TimeSpan.FromMinutes(10);
    
    public Task<SummaryDto> GetSummaryAsync(
        Func<CancellationToken, Task<SummaryDto>> factory,
        CancellationToken cancellationToken = default)
        => service.GetOrCreateAsync(DashboardCacheKeyConstants.GetSummaryCacheKey,
            factory,
            CachedExpiration,
            cancellationToken);

    public async Task InvalidateAsync(CancellationToken cancellationToken)
    {
        await service.RemoveAsync(DashboardCacheKeyConstants.GetSummaryCacheKey, cancellationToken);
    }
}