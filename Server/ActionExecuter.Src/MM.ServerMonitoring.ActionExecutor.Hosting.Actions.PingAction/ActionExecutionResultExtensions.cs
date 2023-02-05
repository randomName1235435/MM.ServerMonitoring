using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Actions.PingAction;

public static class ActionExecutionResultExtensions
{
    public static ActionExecutionResult AddMonitorId(this ActionExecutionResult instance, Guid monitorId)
    {
        instance.MonitorId = monitorId;
        return instance;
    }
}