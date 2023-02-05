using MM.ServerMonitoring.ActionExecutor.Interface;

namespace MM.ServerMonitoring.ActionExecutor.IocContainer.LightInject;

public static class ContainerFactory
{
    public static IContainer Create()
    {
        return new LightInjectWrapper();
    }
}