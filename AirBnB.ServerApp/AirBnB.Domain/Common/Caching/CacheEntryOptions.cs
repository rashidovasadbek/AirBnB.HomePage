namespace AirBnB.Domain.Common.Caching;

public class CacheEntryOptions
{
    public TimeSpan? AbsoluteExpirationRelativeNow { get; init; }
    
    public TimeSpan? SlidingExpiration { get; init; }

    public CacheEntryOptions()
    {
        
    }

    public CacheEntryOptions(TimeSpan absoluteExpirationRelativeNow, TimeSpan slidingExpiration)
    {
        AbsoluteExpirationRelativeNow = absoluteExpirationRelativeNow;
        SlidingExpiration = slidingExpiration;
    }
}