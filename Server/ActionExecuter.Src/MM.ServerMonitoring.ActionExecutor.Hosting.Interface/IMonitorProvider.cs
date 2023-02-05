namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IMonitorProvider
{
    Task<IEnumerable<IMonitor>> ProvideAllAsync(CancellationToken cancellationToken);
}