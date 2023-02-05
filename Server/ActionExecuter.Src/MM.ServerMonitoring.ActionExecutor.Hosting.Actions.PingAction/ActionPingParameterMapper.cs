using MM.ServerMonitoring.ActionExecutor.Infrastructure;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Actions.PingAction;

public class ActionPingParameterMapper : IActionParameterMapper<ActionPingParameter>
{
    public ActionPingParameter Map(ActionConfiguration configuration)
    {
        _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

        var hasTargetParameter = configuration.ParameterCollection
            .Keys.Contains(Constants.ParameterNames.IP);

        if (!hasTargetParameter) throw new InvalidOperationException("no target");

        var target = configuration.ParameterCollection[Constants.ParameterNames.IP];

        return new ActionPingParameter
        {
            PingTarget = target
        };
    }
}