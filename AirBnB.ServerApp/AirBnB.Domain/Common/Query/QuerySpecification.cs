using System.Linq.Expressions;
using System.Text.Json.Serialization.Metadata;
using AirBnB.Domain.Common.Caching;
using AirBnB.Domain.Common.Entities;
using AirBnB.Domain.Comparers;

namespace AirBnB.Domain.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken) : CacheModel where TEntity : IEntity
{

    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = [];

    public List<Expression<Func<TEntity, object>>> IncludeOptions { get; } = [];

    public List<(Expression<Func<TEntity, object>> KeySelecter, bool isAscending)> OrderingOptions { get; } = [];

    public FilterPagination PaginationOptions { get; set; } = new(pageSize, pageToken);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(filter.ToString());

        foreach (var filter in OrderingOptions)
            hashCode.Add(filter.ToString());
        
        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TEntity> querySpecification &&
               querySpecification.GetHashCode() == GetHashCode();
    }

    public override string Cachekey => $"{typeof(TEntity).Name}_{GetHashCode()}";
}