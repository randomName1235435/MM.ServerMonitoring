using System;
using System.Windows.Input;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class CrudCommandFactoryBase
{
    protected CrudCommandFactoryBase(
        ICommand readCommand,
        ICommand readSingleCommand,
        ICommand updateCommand,
        ICommand deleteByIdCommand,
        ICommand insertCommand,
        ICommand showInsertPageCommand,
        ICommand showEditPageCommand,
        ICommand hideInsertPageCommand,
        ICommand hideEditPageCommand,
        ICommand filterCommand
    )
    {
        _ = readCommand ?? throw new ArgumentNullException(nameof(readCommand));
        _ = readSingleCommand ?? throw new ArgumentNullException(nameof(readSingleCommand));
        _ = updateCommand ?? throw new ArgumentNullException(nameof(updateCommand));
        _ = deleteByIdCommand ?? throw new ArgumentNullException(nameof(deleteByIdCommand));
        _ = insertCommand ?? throw new ArgumentNullException(nameof(insertCommand));
        _ = showInsertPageCommand ?? throw new ArgumentNullException(nameof(showInsertPageCommand));
        _ = showEditPageCommand ?? throw new ArgumentNullException(nameof(showEditPageCommand));
        _ = hideInsertPageCommand ?? throw new ArgumentNullException(nameof(hideInsertPageCommand));
        _ = hideEditPageCommand ?? throw new ArgumentNullException(nameof(hideEditPageCommand));
        _ = filterCommand ?? throw new ArgumentNullException(nameof(filterCommand));

        LoadCommand = readCommand;
        LoadSingleCommand = readSingleCommand;
        UpdateCommand = updateCommand;
        DeleteCommand = deleteByIdCommand;
        InsertCommand = insertCommand;
        ShowEditPageCommand = showEditPageCommand;
        ShowInsertPageCommand = showInsertPageCommand;
        HideInsertPageCommand = hideInsertPageCommand;
        HideEditPageCommand = hideEditPageCommand;
        FilterCommand = filterCommand;
    }

    public ICommand LoadCommand { get; }
    public ICommand LoadSingleCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand InsertCommand { get; }
    public ICommand ShowInsertPageCommand { get; }
    public ICommand ShowEditPageCommand { get; }
    public ICommand HideInsertPageCommand { get; }
    public ICommand HideEditPageCommand { get; }
    public ICommand FilterCommand { get; }
}