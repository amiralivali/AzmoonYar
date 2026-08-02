using System.Text.Json;
using AzmoonYar.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Caching.Distributed;

namespace AzmoonYar.Infrastructure.Persistance.Redis.Caching;

public class RedisCacheService(IDistributedCache service) : ICacheService
{
    private static readonly JsonSerializerOptions JsonOptions =
        new JsonSerializerOptions(JsonSerializerDefaults.Web);
    
    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(10)
        };
        var bytes = JsonSerializer.SerializeToUtf8Bytes(value, JsonOptions); 
        await service.SetAsync(key, bytes, options, cancellationToken);
    }

    public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
    {
        var cached = await GetAsync<T>(key, cancellationToken);
        if (cached is not null) return cached;

        var value = await factory();
        if (value is not null)
            await SetAsync(key, value, expiration, cancellationToken);
        return value;
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await service.RemoveAsync(key, cancellationToken);
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var bytes = await service.GetAsync(key, cancellationToken);
        if (bytes is null || bytes.Length == 0)
            return default;
        return JsonSerializer.Deserialize<T>(bytes,JsonOptions);
    }
}