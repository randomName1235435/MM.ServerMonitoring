using System;
using System.Windows;
using System.Windows.Threading;
using MM.ServerMonitoring.Consumer.Wpf.Interface;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Services;

public class Dispatcher : IDispatcher
{
    public void Invoke(Action action)
    {
        if (Application.Current == null)
            action();
        else
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
    }
}