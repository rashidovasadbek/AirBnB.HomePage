using System.Linq.Expressions;

namespace AirBnB.Domain.Comparers;

public class OrderExpressionComparer<TSource> : IComparer<(Expression<Func<TSource, bool>> keySelecter, bool IsAscending)>
{
    public int Compare(
        (Expression<Func<TSource, bool>> keySelecter, bool IsAscending) x,
        (Expression<Func<TSource, bool>> keySelecter, bool IsAscending) y)
    {
        if (ReferenceEquals(x.keySelecter, y.keySelecter)) return 0;
        if (ReferenceEquals(null, y.keySelecter)) return 1;
        if (ReferenceEquals(null, x.keySelecter)) return -1;

        var keySelectorComparison =
            string.Compare(x.keySelecter.ToString(), y.keySelecter.ToString(), StringComparison.Ordinal);

        return keySelectorComparison != 0
              ? keySelectorComparison 
              : Comparer<bool>.Default.Compare(x.IsAscending, y.IsAscending);
    }
}