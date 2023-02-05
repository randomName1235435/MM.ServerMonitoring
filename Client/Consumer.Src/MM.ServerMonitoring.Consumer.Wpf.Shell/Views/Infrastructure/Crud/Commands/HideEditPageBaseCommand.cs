using System;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class HideEditPageBaseCommand<TDto> : ICommand
{
    private readonly HideEditPageEvent<TDto> hideEvent;
    private readonly EditPageIsHiddenEvent<TDto> isHiddenEvent;
    private readonly EditPageIsShowingEvent<TDto> isShowingEvent;

    private bool canExecute = true;

    public HideEditPageBaseCommand(IEventAggregator eventAggregator)
    {
        this.hideEvent = eventAggregator.GetEvent<HideEditPageEvent<TDto>>();
        this.isShowingEvent = eventAggregator.GetEvent<EditPageIsShowingEvent<TDto>>();
        this.isShowingEvent.Subscribe(this.IsShowing);
        this.isHiddenEvent = eventAggregator.GetEvent<EditPageIsHiddenEvent<TDto>>();
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
        this.hideEvent.Publish();
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