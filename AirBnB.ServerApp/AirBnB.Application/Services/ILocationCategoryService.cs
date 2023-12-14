using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Services;

public interface ILocationCategoryService
{
    IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false);
    
    ValueTask<IList<LocationCategory>> GetAsync(
        QuerySpecification<LocationCategory> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
    ValueTask<IList<LocationCategory>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<LocationCategory?> GetByIdAsync(Guid locationId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}