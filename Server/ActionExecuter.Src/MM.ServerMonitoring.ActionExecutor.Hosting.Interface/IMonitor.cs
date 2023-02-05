using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IMonitor
{
    Task<ActionExecutionResult> RunAsync(CancellationToken stoppingToken);
}