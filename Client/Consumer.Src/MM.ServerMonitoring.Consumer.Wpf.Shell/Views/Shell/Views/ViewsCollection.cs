using System.Collections.Generic;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Views;

public static class ViewsCollection
{
    public static IEnumerable<ViewInfo> All()
    {
        return new ViewInfo[]
        {
            new("monitor", '', container => container.Resolve<MonitorView.MonitorView>()),
            new("results", '', container => container.Resolve<SimpleActionResultView.SimpleActionResultView>())
        };
    }

    public static ViewInfo LogView()
    {
        return new ViewInfo("logView", '', container => container.Resolve<LogView.LogView>());
    }

    public static ViewInfo DesignTimeLogView()
    {
        return new ViewInfo("logView", '', container => new LogView.LogView());
    }

    public static IEnumerable<ViewInfo> DesignTime()
    {
        return new[]
        {
            new("monitor", '', container => new MonitorView.MonitorView
            {
                DataContext = new MonitorViewModel()
            }),
            new ViewInfo("monitor", 'X', container => new MonitorView.MonitorView())
        };
    }
}