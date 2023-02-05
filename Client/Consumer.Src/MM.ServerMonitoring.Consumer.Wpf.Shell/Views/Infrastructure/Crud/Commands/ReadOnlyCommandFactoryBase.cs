using System;
using System.Windows.Input;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class ReadOnlyCommandFactoryBase
{
    protected ReadOnlyCommandFactoryBase(
        ICommand readCommand,
        ICommand filterCommand
    )
    {
        _ = readCommand ?? throw new ArgumentNullException(nameof(readCommand));
        _ = filterCommand ?? throw new ArgumentNullException(nameof(filterCommand));

        LoadCommand = readCommand;
        FilterCommand = filterCommand;
    }

    public ICommand LoadCommand { get; }
    public ICommand FilterCommand { get; }
}