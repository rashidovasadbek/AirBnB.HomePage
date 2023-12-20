using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Locations.Models;

public class LocationFilter : FilterPagination, IQueryConvertible<Location>
{
    public Guid? CategoryId { get; set; }
    
    public string? Category { get; set; }
    
    public QuerySpecification<Location> ToQuerySpecification()
    {
        var querySpecification = new QuerySpecification<Location>(PageSize, PageToken, GetHashCode());

        if (Category is not null)
        {
            querySpecification.IncludeOptions.Add(location => location.Category!);
            querySpecification.FilteringOptions.Add(location => location.Category!.Name.Equals(Category));
        }

        if (CategoryId is not null)
        {
            querySpecification.FilteringOptions.Add(location => location.CategoryId == CategoryId);
        }
        querySpecification.PaginationOptions = this;
        
        return querySpecification;
    }

    public override bool Equals(object? obj)
    {
        return obj is LocationFilter locationFilter && locationFilter.GetHashCode().Equals(GetHashCode());
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);
        
        if(CategoryId.HasValue)
            hashCode.Add(CategoryId.Value);

        return hashCode.ToHashCode();
    }
}