using System.Collections.Immutable;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Logging;

public class SimpleEventLogger : ILogger, IReadableLogger
{
    private static SimpleEventLogger instance;
    private readonly List<string> logs = new();
    private readonly LogAddedEvent newLogs;

    private SimpleEventLogger(IEventAggregator eventAggregator)
    {
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

        this.newLogs = eventAggregator.GetEvent<LogAddedEvent>();
    }

    public void Exception(Exception exception)
    {
        var formatted = string.Format("Exception: {0}", exception.Message);
        lock (this.logs)
        {
            this.logs.Add(formatted);
        }

        this.newLogs.Publish(formatted);
    }

    public void Info(string message)
    {
        var formatted = string.Format("Info: {0}", message);
        lock (this.logs)
        {
            this.logs.Add(formatted);
        }

        this.newLogs.Publish(formatted);
    }

    public IReadOnlyCollection<string> Messages
    {
        get
        {
            IReadOnlyCollection<string> immutable = null;
            lock (this.logs)
            {
                immutable = this.logs.ToImmutableArray();
            }

            return immutable;
        }
    }

    public static SimpleEventLogger Create(IEventAggregator eventAggregator)
    {
        return new SimpleEventLogger(eventAggregator);
    }
}