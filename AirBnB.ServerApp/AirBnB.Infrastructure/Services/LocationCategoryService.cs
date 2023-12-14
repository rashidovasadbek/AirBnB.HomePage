using System.Linq.Expressions;
using AirBnB.Application.Services;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interface;

namespace AirBnB.Infrastructure.Services;

public class LocationCategoryService(ILocationCategoryRepository locationCategoryRepository) : ILocationCategoryService
{
    public IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false)
    {
        return locationCategoryRepository.Get(predicate, asNoTracking);
    }

    public async ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await locationCategoryRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }

    public ValueTask<IList<LocationCategory>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<LocationCategory?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return locationCategoryRepository.GetByIdAsync(locationId, asNoTracking, cancellationToken);
    }
}