using System.Linq.Expressions;
using System.Text.Json.Serialization.Metadata;
using AirBnB.Domain.Common.Caching;
using AirBnB.Domain.Common.Entities;
using AirBnB.Domain.Comparers;
using Microsoft.EntityFrameworkCore.Query;

namespace AirBnB.Domain.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken, int? hashCode = default ) : CacheModel where TEntity : IEntity
{
    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = [];

    public List<Expression<Func<TEntity, object>>> IncludeOptions { get; } = [];

    public List<(Expression<Func<TEntity, object>> KeySelecter, bool isAscending)> OrderingOptions { get; } = [];

    public FilterPagination PaginationOptions { get; set; } = new(pageSize, pageToken);

    public int? FilterHashCode { get; init; } = hashCode;

    public override int GetHashCode()
    {
        if (FilterHashCode.HasValue) return FilterHashCode.Value;
        
        var expressionEqualityComparer = ExpressionEqualityComparer.Instance;
        var hashCode = new HashCode();

        var test = expressionEqualityComparer.GetHashCode(FilteringOptions[0]);
        
        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(expressionEqualityComparer.GetHashCode(filter));

        foreach (var filter in OrderingOptions)
        {
            hashCode.Add(expressionEqualityComparer.GetHashCode(filter.KeySelecter));
            hashCode.Add(filter.isAscending);
        }
        
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