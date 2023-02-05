using MM.ServerMonitoring.Provider.WebApi.Interface;

namespace MM.ServerMonitoring.Provider.WebApi.IocContainer.LightInject;

public static class ContainerFactory
{
    public static IContainer Create()
    {
        return new LightInjectWrapper();
    }
}