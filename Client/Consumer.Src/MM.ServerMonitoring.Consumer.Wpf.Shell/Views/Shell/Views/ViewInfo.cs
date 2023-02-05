using System;
using System.Windows.Controls;
using MM.ServerMonitoring.Consumer.Wpf.Interface;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Views;

public class ViewInfo
{
    public ViewInfo(string viewName, char iconChar, Func<IContainer, Control> getView)
    {
        ViewName = viewName;
        IconChar = iconChar;
        GetView = getView;
    }

    public char IconChar { get; init; }
    public string ViewName { get; init; }
    public Func<IContainer, Control> GetView { get; init; }
}