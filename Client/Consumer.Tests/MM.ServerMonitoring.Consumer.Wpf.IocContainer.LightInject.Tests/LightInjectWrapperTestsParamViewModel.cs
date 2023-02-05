using MM.ServerMonitoring.Consumer.Wpf.Interface.View;

namespace MM.ServerMonitoring.Consumer.Wpf.IocContainer.LightInject.Tests;

public class LightInjectWrapperTestsParamViewModel : IViewModel
{
    public LightInjectWrapperTestsParamViewModel()
    {
        CreatedInstances++;
    }

    public static int CreatedInstances { get; set; }

    public void ViewReady()
    {
    }
}