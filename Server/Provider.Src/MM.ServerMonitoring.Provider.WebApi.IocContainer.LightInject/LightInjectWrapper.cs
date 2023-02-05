using LightInject;
using MM.ServerMonitoring.Provider.WebApi.Interface;

namespace MM.ServerMonitoring.Provider.WebApi.IocContainer.LightInject;

public class LightInjectWrapper : ServiceContainer, IContainer
{
    public void Register<TInterface, TImplementation>()
        where TImplementation : TInterface
    {
        base.Register<TInterface, TImplementation>();
    }

    public TInterface Resolve<TInterface>()
    {
        return this.GetInstance<TInterface>();
    }
}