using System;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class ShowEditPageBaseCommand<TDto> : ICommand
{
    private readonly ShowEditPageEvent<TDto> showEvent;
    private readonly IEditView<TDto> view;

    //todo should only work if data loaded or server healty
    private bool canExecute = true;

    public ShowEditPageBaseCommand(IEventAggregator eventAggregator, IEditView<TDto> view)
    {
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _ = view ?? throw new ArgumentNullException(nameof(view));

        this.view = view;
        this.showEvent = eventAggregator.GetEvent<ShowEditPageEvent<TDto>>();
        var isShowingEvent = eventAggregator.GetEvent<EditPageIsShowingEvent<TDto>>();
        isShowingEvent.Subscribe(this.IsShowing);
        var isHiddenEvent = eventAggregator.GetEvent<EditPageIsHiddenEvent<TDto>>();
        isHiddenEvent.Subscribe(this.IsHidden);
    }

    public bool CanExecute(object? parameter)
    {
        return this.canExecute;
    }

    public void Execute(object? parameter)
    {
        this.canExecute = false;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        this.showEvent.Publish(this.view);
    }

    public event EventHandler? CanExecuteChanged;

    private void IsHidden()
    {
        this.canExecute = true;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    private void IsShowing()
    {
        this.canExecute = false;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}