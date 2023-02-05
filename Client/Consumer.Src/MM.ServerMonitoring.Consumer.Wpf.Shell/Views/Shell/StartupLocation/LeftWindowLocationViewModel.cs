using System.Windows;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.StartupLocation;

public class LeftWindowLocationViewModel : WindowLocationViewModel

{
    public LeftWindowLocationViewModel()
    {
        Top = 0;
        Left = 0 - DefaultBorderWidth;
        WindowState = WindowState.Normal;
        StartupLocation = WindowStartupLocation.Manual;
        Width = SystemParameters.PrimaryScreenWidth / 2 + DefaultBorderWidth * 2;
        Height = SystemParameters.PrimaryScreenHeight - DefaultTaskbarAndBorderWidth;
    }
}