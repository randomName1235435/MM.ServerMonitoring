using System.Windows;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.StartupLocation;

public class RightWindowLocationViewModel : WindowLocationViewModel

{
    public RightWindowLocationViewModel()
    {
        Top = 0;
        Left = SystemParameters.PrimaryScreenWidth / 2 - DefaultBorderWidth;
        WindowState = WindowState.Normal;
        Width = SystemParameters.PrimaryScreenWidth / 2 + DefaultBorderWidth * 2;
        Height = SystemParameters.PrimaryScreenHeight - DefaultTaskbarAndBorderWidth;
    }
}