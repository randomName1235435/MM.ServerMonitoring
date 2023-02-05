using LightInject;
using MM.ServerMonitoring.ActionExecutor.Interface;

namespace MM.ServerMonitoring.ActionExecutor.IocContainer.LightInject;

public class LightInjectWrapper : ServiceContainer, IContainer
{
    public new void Register<TInterface, TImplementation>()
        where TImplementation : TInterface
    {
        base.Register<TInterface, TImplementation>();
    }

    public TInterface Resolve<TInterface>()
    {
        return this.GetInstance<TInterface>();
    }
}