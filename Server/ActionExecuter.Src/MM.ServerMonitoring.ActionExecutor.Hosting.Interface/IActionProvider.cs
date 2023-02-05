using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IActionProvider
{
    IAction Provide(ActionConfiguration configuration);
}