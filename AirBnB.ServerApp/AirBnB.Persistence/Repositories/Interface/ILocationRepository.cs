using System.Linq.Expressions;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace AirBnB.Persistence.Repositories.Interface;

public interface ILocationRepository
{
    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<Location>> GetAsync(
        QuerySpecification<Location> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
    ValueTask<IList<Location>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    
    
}