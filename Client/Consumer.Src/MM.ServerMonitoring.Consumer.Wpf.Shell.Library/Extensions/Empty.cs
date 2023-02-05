using System.Collections.ObjectModel;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Extensions;

public static class Empty
{
    /// adaption from array.empty
    public static ObservableCollection<T> ObservableCollection<T>()
    {
        return EmptyObservableCollection<T>.Value;
    }

    private static class EmptyObservableCollection<T>
    {
        internal static readonly ObservableCollection<T> Value = new();
    }
}