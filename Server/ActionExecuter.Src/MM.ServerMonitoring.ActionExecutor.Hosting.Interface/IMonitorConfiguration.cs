using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IMonitorConfiguration
{
    Task<IEnumerable<MonitorConfiguration>> GetAsync(CancellationToken cancellationToken);
}