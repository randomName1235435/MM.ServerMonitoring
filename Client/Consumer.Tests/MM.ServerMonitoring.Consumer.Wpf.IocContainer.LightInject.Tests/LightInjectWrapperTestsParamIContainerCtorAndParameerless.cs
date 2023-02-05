using MM.ServerMonitoring.Consumer.Wpf.Interface;

namespace MM.ServerMonitoring.Consumer.Wpf.IocContainer.LightInject.Tests;

public class LightInjectWrapperTestsParamIContainerCtorAndParameerless
{
    public LightInjectWrapperTestsParamIContainerCtorAndParameerless(IContainer container)
    {
        Container = container;
    }

    public LightInjectWrapperTestsParamIContainerCtorAndParameerless()
    {
    }

    public IContainer Container { get; }
}