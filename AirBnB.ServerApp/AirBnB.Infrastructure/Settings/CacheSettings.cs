namespace AirBnB.Infrastructure.Settings;

public class CacheSettings
{
    public uint AbsoluteExpirationIsSeconds { get; set; }
    
    public uint SlidingExpirationInSeconds { get; set; }
}