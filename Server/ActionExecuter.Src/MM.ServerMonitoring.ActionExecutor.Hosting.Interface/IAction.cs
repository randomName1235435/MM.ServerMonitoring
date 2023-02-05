using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IAction
{
    Task<ActionExecutionResult> ExecuteAsync(CancellationToken token);
}