using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public abstract class FilterBaseCommand<TDto> : ICommand
{
    private readonly FilterSuccessEventTDto<TDto> successEvent;
    private bool isRunning;
    private IEnumerable<TDto> itemCollection = Array.Empty<TDto>();

    protected FilterBaseCommand(IEventAggregator eventAggregator)
    {
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

        var dataLoadedEvent = eventAggregator.GetEvent<DataLoadedSucceedEvent<TDto>>();
        dataLoadedEvent.Subscribe(this.DataLoaded);
        this.successEvent = eventAggregator.GetEvent<FilterSuccessEventTDto<TDto>>();
    }

    public bool CanExecute(object? parameter)
    {
        return this.itemCollection.Any() && !this.isRunning;
    }

    public void Execute(object? parameter)
    {
        var filter = new Func<string, IEnumerable<TDto>>(filterString =>
        {
            return this.itemCollection.Where(item => this.Match(item, filterString));
        });
        if (parameter == null || string.IsNullOrEmpty(parameter.ToString()))
            filter = b => this.itemCollection;

        this.isRunning = true;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        var filtered = filter(parameter?.ToString());

        this.successEvent.Publish(filtered);

        this.isRunning = false;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? CanExecuteChanged;

    private void DataLoaded(IEnumerable<TDto> obj)
    {
        this.itemCollection = obj;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    protected abstract bool Match(TDto item, string filterString);
}