using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.LogView.Events;
using Prism.Events;
using Prism.Mvvm;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.LogView;

public class LogViewModel : BindableBase, IViewModel
{
    private readonly IDispatcher dispatcher;
    private readonly LogAddedEvent logAddedEvent;
    private readonly IReadableLogger logger;

    private ObservableCollection<string> logs;

    public LogViewModel()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            this.logs = new ObservableCollection<string>
            {
                "test", "test"
            };
        else
            throw new Exception("Only Designtime");
    }

    public LogViewModel(
        IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        IReadableLogger logger
    )
    {
        _ = eventAggregator ?? throw new ArgumentException(nameof(eventAggregator));
        _ = dispatcher ?? throw new ArgumentException(nameof(dispatcher));
        _ = logger ?? throw new ArgumentException(nameof(logger));

        this.dispatcher = dispatcher;
        this.logger = logger;
        this.logAddedEvent = eventAggregator.GetEvent<LogAddedEvent>();
        this.logs = new ObservableCollection<string>();
    }

    public ObservableCollection<string> Logs
    {
        get => this.logs;
        set => this.SetProperty(ref this.logs, value);
    }

    public void ViewReady()
    {
        this.dispatcher.Invoke(() =>
        {
            Logs = new ObservableCollection<string>(this.logger.Messages);
            this.logAddedEvent.Subscribe(this.LogAdded);
        });
    }

    private void LogAdded(string obj)
    {
        this.dispatcher.Invoke(() => Logs.Insert(0, obj));
    }
}