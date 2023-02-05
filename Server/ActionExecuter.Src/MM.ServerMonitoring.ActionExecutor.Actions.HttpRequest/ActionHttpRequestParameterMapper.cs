using MM.ServerMonitoring.ActionExecutor.Infrastructure;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Actions.HttpRequest;

public class ActionHttpRequestParameterMapper : IActionParameterMapper<ActionHttpRequestParameter>
{
    public ActionHttpRequestParameter Map(ActionConfiguration configuration)
    {
        _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

        var hasTargetParameter = configuration.ParameterCollection
            .Keys.Contains(Constants.ParameterNames.Url);

        if (!hasTargetParameter) throw new InvalidOperationException("no target");

        var target = configuration.ParameterCollection[Constants.ParameterNames.Url];

        return new ActionHttpRequestParameter
        {
            Url = target
        };
    }
}