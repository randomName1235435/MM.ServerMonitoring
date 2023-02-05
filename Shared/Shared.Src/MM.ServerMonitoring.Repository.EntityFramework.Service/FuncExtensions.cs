namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public static class FuncExtensions
{
    public static T ApplyIfNotNull<T>(this T @this, Func<T, T> fn)
    {
        return fn == null ? @this : fn(@this);
    }
}