using AirBnB.Domain.Common.Caching;
using AirBnB.Infrastructure.Settings;
using AirBnB.Persistence.Caching.Brokers;
using Force.DeepCloner;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace AirBnB.Infrastructure.Common.Caching.Brokers;

public class LazyMemoryCacheBroker(IAppCache appCache, IOptions<CacheSettings> cacheSettings) : ICacheBroker
{

    private readonly MemoryCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationIsSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };
    
    public async ValueTask<T> GetASync<T>(string key)
        => await appCache.GetAsync<T>(key);

    public  ValueTask<bool> TryGetAsync<T>(string key, out T? value)
    {
        return new ValueTask<bool>(appCache.TryGetValue(key, out value));
    } 

    public async ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? cacheEntryOptions)
    {
        return await appCache.GetOrAddAsync(key, valueFactory, GetCacheEntryOptions(cacheEntryOptions));
        
    }

    public ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = default)
    {
       appCache.Add(key, value, GetCacheEntryOptions(cacheEntryOptions));

       return ValueTask.CompletedTask;
    }

    public ValueTask DeleteAsync(string key)
    {
        appCache.Remove(key);
        
        return ValueTask.CompletedTask;
    }

    public MemoryCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? cacheEntryOptions)
    {
        if (cacheEntryOptions == default || (!cacheEntryOptions.AbsoluteExpirationRelativeNow.HasValue && !cacheEntryOptions.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = cacheEntryOptions.AbsoluteExpirationRelativeNow;
        currentEntryOptions.AbsoluteExpirationRelativeToNow = cacheEntryOptions.SlidingExpiration;

        return currentEntryOptions;
    }
}