using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Locations.Models;

public class LocationFilter : FilterPagination, IQueryConvertible<Location>
{
    public string Category { get; set; } = default!;
    
    public QuerySpecification<Location> ToQuerySpecification()
    {
        var querySpecification = new QuerySpecification<Location>(PageSize, PageToken);

        querySpecification.IncludeOptions.Add(location => location.Category);
        querySpecification.FilteringOptions.Add(location => location.Category.Name.Equals("Castle"));

        return querySpecification;
    }
}