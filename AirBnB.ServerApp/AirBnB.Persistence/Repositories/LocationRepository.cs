using System.Linq.Expressions;
using AirBnB.Domain.Common.Caching;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.DataContext;
using AirBnB.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.Repositories;

public class LocationRepository(AirBnBdbContext airBnBdbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<Location, AirBnBdbContext>(
    airBnBdbContext,
    cacheBroker,
    new CacheEntryOptions()
    ), ILocationRepository
{

    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public ValueTask<IList<Location>> GetAsync(
        QuerySpecification<Location> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        return base.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }
    
    public ValueTask<IList<Location>> GetByIdsAsync(IEnumerable<Guid> ids, 
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<Location?> GetByIdAsync(Guid locationId,
        bool asNoTracking = false, 
        CancellationToken cancellationToken = default)
        => base.GetByIdAsync(locationId, asNoTracking, cancellationToken);
    
    public new ValueTask<Location> CreateAsync(Location user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public new ValueTask<Location> UpdateAsync(Location user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public new ValueTask<Location?> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdsAsync(userId, saveChanges, cancellationToken);
    }
}