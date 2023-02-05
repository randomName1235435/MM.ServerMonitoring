using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public class MonitorFactory : IMonitorFactory
{
    private readonly IMinimalRepository<ActionExecutionResult> repository;

    public MonitorFactory(IMinimalRepository<ActionExecutionResult> repository)
    {
        _ = repository ?? throw new ArgumentNullException(nameof(repository));

        this.repository = repository;
    }

    public IMonitor Create(IAction action, ActionConfiguration actionConfiguration, Guid monitorId)
    {
        return new Monitor(actionConfiguration, action, this.repository, monitorId);
    }
}