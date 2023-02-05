using System;
using System.Windows;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;

public class WindowBase : Window
{
    public void NotifyOnLoaded(Action notify)
    {
        Loaded += (_, _) => notify?.Invoke();
    }
}