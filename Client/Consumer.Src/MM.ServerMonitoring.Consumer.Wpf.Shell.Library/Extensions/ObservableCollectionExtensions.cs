using System.Collections.ObjectModel;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Extensions;

public static class ObservableCollectionExtensions
{
    public static void RemoveItems<T>(this ObservableCollection<T> collection, IEnumerable<T> toRemove)
    {
        foreach (var item in toRemove) collection.Remove(item);
    }

    public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> toAdd)
    {
        foreach (var item in toAdd) collection.Add(item);
    }
}