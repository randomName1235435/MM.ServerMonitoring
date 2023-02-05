using System.Windows;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.StartupLocation;

public class MaximizedWindowLocationViewModel : WindowLocationViewModel

{
    public MaximizedWindowLocationViewModel()
    {
        WindowState = WindowState.Maximized;
    }
}