using MM.ServerMonitoring.Consumer.Wpf.Interface.View;

namespace MM.ServerMonitoring.Consumer.Wpf.IocContainer.LightInject.Tests;

public class LightInjectWrapperTestsParamViewMock : IView
{
    public object DataContext { get; set; }

    public void NotifyOnLoaded(Action notify)
    {
    }
}