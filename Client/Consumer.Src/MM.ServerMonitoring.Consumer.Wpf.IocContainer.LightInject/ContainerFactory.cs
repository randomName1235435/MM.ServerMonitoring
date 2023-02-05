using MM.ServerMonitoring.Consumer.Wpf.Interface;

namespace MM.ServerMonitoring.Consumer.Wpf.IocContainer.LightInject;

public static class ContainerFactory
{
    public static IContainer Create(ILogger logger)
    {
        return new LightInjectWrapper(logger);
    }
}