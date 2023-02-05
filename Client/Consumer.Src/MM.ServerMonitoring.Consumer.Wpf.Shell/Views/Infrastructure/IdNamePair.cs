using System;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;

public class IdNamePair : IFilterableItemViewModel
{
    public IdNamePair(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }

    public string Text => $"{Id} - {Name}";

    public bool Contains(string filter)
    {
        return Text.Contains(filter);
    }

    public override string ToString()
    {
        return Text;
    }
}