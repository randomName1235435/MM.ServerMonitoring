using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IMonitorFactory
{
    IMonitor Create(IAction action, ActionConfiguration workerConfiguration, Guid monitorId);
}