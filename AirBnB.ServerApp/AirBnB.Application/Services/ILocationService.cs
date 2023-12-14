using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Services;

public interface ILocationService
{
    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<Location>> GetByFilterAsync(
        QuerySpecification<Location> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    ValueTask<Location> GetByIdAsync(Guid locationId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);
      
    ValueTask<Location> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
}