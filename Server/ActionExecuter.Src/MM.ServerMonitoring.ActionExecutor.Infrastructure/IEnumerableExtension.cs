using System.Collections.ObjectModel;

namespace MM.ServerMonitoring.ActionExecutor.Infrastructure;

public static class IEnumerableExtension
{
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (var item in enumeration) action(item);
        return enumeration;
    }

    public static int AsIntOrMax(this double value)
    {
        if (value > int.MaxValue)
            return int.MaxValue;
        return (int)value;
    }

    public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(
        this IEnumerable<TSource> source, Func<TSource, Task<TResult>> method)
    {
        return await Task.WhenAll(source.Select(async s => await method(s)));
    }

    public static ReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(
        this Dictionary<TKey, TValue> source)
    {
        return new ReadOnlyDictionary<TKey, TValue>(source);
    }

    public static IReadOnlyDictionary<TKey, TValue> AsIReadOnlyDictionary<TKey, TValue>(
        this Dictionary<TKey, TValue> source)
    {
        return source;
    }
}