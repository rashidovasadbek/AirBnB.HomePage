using System.Linq.Expressions;
using AirBnB.Application.Services;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interface;

namespace AirBnB.Infrastructure.Services;

public class LocationService(ILocationRepository locationRepository) : ILocationService
{
    
    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false)
    {
        return locationRepository.Get(predicate, asNoTracking);
    }
    
    public async ValueTask<IList<Location>> GetAsync(
        QuerySpecification<Location> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        return await locationRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }

    public async ValueTask<IList<Location>> GetByFilterAsync(
        QuerySpecification<Location> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => await locationRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return locationRepository.GetByIdAsync(locationId, asNoTracking, cancellationToken);
    }

    public ValueTask<Location> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    
}