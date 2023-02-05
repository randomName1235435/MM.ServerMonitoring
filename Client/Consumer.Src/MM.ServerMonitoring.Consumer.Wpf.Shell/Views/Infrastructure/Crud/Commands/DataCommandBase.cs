using System;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class DataCommandBase<TDto, TSucceedEvent, TFailedEvent, TRepository>
    where TSucceedEvent : EventBase, new()
    where TFailedEvent : EventBase, new()
{
    protected readonly IDispatcher dispatcher;
    protected readonly TFailedEvent failedEvent;
    protected readonly ILogger logger;
    protected readonly IMessageBoxService messageBoxService;
    protected readonly TRepository repository;
    protected readonly TSucceedEvent succeedEvent;
    protected bool isRunning;

    public DataCommandBase(
        IEventAggregator eventAggregator,
        IMessageBoxService messageBoxService,
        TRepository repository,
        IDispatcher dispatcher,
        ILogger logger
    )
    {
        _ = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        _ = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _ = repository ?? throw new ArgumentNullException(nameof(repository));
        _ = logger ?? throw new ArgumentNullException(nameof(logger));

        this.succeedEvent = eventAggregator.GetEvent<TSucceedEvent>();
        this.failedEvent = eventAggregator.GetEvent<TFailedEvent>();

        this.messageBoxService = messageBoxService;
        this.dispatcher = dispatcher;
        this.repository = repository;
        this.logger = logger;
    }

    public event EventHandler? CanExecuteChanged;

    protected void NotifyRunning()
    {
        this.dispatcher.Invoke(() =>
        {
            this.isRunning = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        });
    }

    protected void NotifyStopped()
    {
        this.dispatcher.Invoke(() =>
        {
            this.isRunning = false;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        });
    }
}