using System.Text;
using AirBnB.Domain.Common.Caching;
using AirBnB.Infrastructure.Settings;
using AirBnB.Persistence.Caching.Brokers;
using Force.DeepCloner;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AirBnB.Infrastructure.Common.Caching.Brokers;

public class RedisDistributedCacheBroker(IOptions<CacheSettings> cacheSettings, IDistributedCache distributedCache) : ICacheBroker
{
    private readonly DistributedCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1200),//cacheSettings.Value.AbsoluteExpirationIsSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(60),//cacheSettings.Value.SlidingExpirationInSeconds)
    };
    public async ValueTask<T> GetASync<T>(string key)
    {
        var value = await distributedCache.GetAsync(key);
        return value is not null ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value)) : default;
    }

    public ValueTask<bool> TryGetAsync<T>(string key, out T? value)
    {
        var foundEntry = distributedCache.GetString(key);

        if (foundEntry is not null)
        {
            value = JsonConvert.DeserializeObject<T>(foundEntry);
            return ValueTask.FromResult(true);
        }

        value = default;
        return ValueTask.FromResult(false);
    }

    public async ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? cacheEntryOptions = default)
    {
        var cachedValue = await distributedCache.GetStringAsync(key);
        if (cachedValue is not null) return JsonConvert.DeserializeObject<T>(cachedValue);

        var value = await valueFactory();
        await SetAsync(key, await valueFactory(), cacheEntryOptions);

        return value;
    }

    public async ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = default)
    {
        await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value),
            GetCacheEntryOptions(cacheEntryOptions));
    }

    public ValueTask DeleteAsync(string key)
    {
        distributedCache.Remove(key);
        
        return ValueTask.CompletedTask;
    }
    
    public DistributedCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? entryOptions)
    {
        if (entryOptions == default || (!entryOptions.AbsoluteExpirationRelativeNow.HasValue && !entryOptions.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = entryOptions.AbsoluteExpirationRelativeNow;
        currentEntryOptions.SlidingExpiration = entryOptions.SlidingExpiration;

        return currentEntryOptions;
    }
}