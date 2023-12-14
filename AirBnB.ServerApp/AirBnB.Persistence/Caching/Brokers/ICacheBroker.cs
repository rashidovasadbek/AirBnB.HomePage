using AirBnB.Domain.Common.Caching;

namespace AirBnB.Persistence.Caching.Brokers;

public interface ICacheBroker
{
    ValueTask<T> GetASync<T>(string key);

    ValueTask<bool> TryGetAsync<T>(string key, out T? value);
    
    ValueTask<T> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? cacheEntryOptions);

    ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? cacheEntryOptions = default);

    ValueTask DeleteAsync(string key);
}