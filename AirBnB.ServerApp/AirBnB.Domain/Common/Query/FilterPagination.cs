namespace AirBnB.Domain.Common.Query;

public class FilterPagination
{
    public uint PageSize { get; init; } = 10;

    public uint PageToken { get; init; } = 1;

    public FilterPagination(uint pageSize, uint pageToken)
    {
        PageSize = pageSize;
        PageToken = pageToken;
    }

    public FilterPagination()
    {
        
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        
        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is FilterPagination filterPagination && filterPagination.GetHashCode() == GetHashCode();
    }
    
}