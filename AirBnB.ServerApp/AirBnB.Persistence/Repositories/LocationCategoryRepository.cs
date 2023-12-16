using System.Linq.Expressions;
using AirBnB.Domain.Common.Caching;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.DataContext;
using AirBnB.Persistence.Repositories.Interface;

namespace AirBnB.Persistence.Repositories;

public class LocationCategoryRepository(AirBnBdbContext airBnBdbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<LocationCategory, AirBnBdbContext>(
    airBnBdbContext,
    cacheBroker,
    new CacheEntryOptions()
), ILocationCategoryRepository
{
    public IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);
    

    public ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }

    public ValueTask<IList<LocationCategory>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => base.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<LocationCategory?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(locationId, asNoTracking, cancellationToken);
}