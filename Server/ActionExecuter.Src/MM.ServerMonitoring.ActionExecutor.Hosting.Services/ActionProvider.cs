using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public class ActionProvider : IActionProvider
{
    private readonly IDictionary<Guid, Func<ActionConfiguration, IAction>> actionFactoryCollection;

    public ActionProvider() : this(Default.ActionFactories)
    {
        IsDefaultConfig = true;
    }

    public ActionProvider(IDictionary<Guid, Func<ActionConfiguration, IAction>> actionFactoryCollection)
    {
        this.actionFactoryCollection = actionFactoryCollection;
    }

    public bool IsDefaultConfig { get; }

    public IAction Provide(ActionConfiguration configuration)
    {
        if (!this.HasAction(configuration))
            return null;
        var action = this.actionFactoryCollection[configuration.ActionId]
            .Invoke(configuration);
        return action;
    }

    public bool HasAction(ActionConfiguration configuration)
    {
        return this.actionFactoryCollection.ContainsKey(configuration.ActionId);
    }
}