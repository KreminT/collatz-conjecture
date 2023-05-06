namespace CollatzConjecture.Math;

public static class CollectionExtensions
{
    public static IEnumerable<TType> GetBetween<TType>(this IEnumerable<TType> values, int? startIndex, int? endIndex)
    {
        if (startIndex is > -1)
            values = values.Skip(startIndex.Value);
        if (endIndex is > 0)
            values = values.Take(endIndex.Value - startIndex ?? -1);
        return values;
    }
}