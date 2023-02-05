using System;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class HideInsertPageBaseCommand<TDto> : ICommand
{
    private readonly HideInsertPageEvent<TDto> HideEvent;
    private readonly InsertPageIsHiddenEvent<TDto> isHiddenEvent;
    private readonly InsertPageIsShowingEvent<TDto> isShowingEvent;

    private bool canExecute = true;

    public HideInsertPageBaseCommand(IEventAggregator eventAggregator)
    {
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

        this.HideEvent = eventAggregator.GetEvent<HideInsertPageEvent<TDto>>();
        this.isShowingEvent = eventAggregator.GetEvent<InsertPageIsShowingEvent<TDto>>();
        this.isShowingEvent.Subscribe(this.IsShowing);
        this.isHiddenEvent = eventAggregator.GetEvent<InsertPageIsHiddenEvent<TDto>>();
        this.isHiddenEvent.Subscribe(this.IsHidden);
    }

    public bool CanExecute(object? parameter)
    {
        return this.canExecute;
    }

    public void Execute(object? parameter)
    {
        this.canExecute = false;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        this.HideEvent.Publish();
    }

    public event EventHandler? CanExecuteChanged;

    private void IsHidden()
    {
        this.canExecute = false;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    private void IsShowing()
    {
        this.canExecute = true;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}