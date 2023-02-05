using System.Windows;
using Prism.Mvvm;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.StartupLocation;

public class WindowLocationViewModel : BindableBase
{
    protected const int DefaultBorderWidth = 7;
    protected const int DefaultTaskbarAndBorderWidth = 33;
    private double height = 1040;
    private double left;
    private WindowStartupLocation startupLocation;
    private double top;
    private double width = 1500;
    private WindowState windowState;

    public WindowState WindowState
    {
        get => windowState;
        set => SetProperty(ref windowState, value);
    }

    public WindowStartupLocation StartupLocation
    {
        get => startupLocation;
        set => SetProperty(ref startupLocation, value);
    }

    public double Top
    {
        get => top;
        set => SetProperty(ref top, value);
    }

    public double Left
    {
        get => left;
        set => SetProperty(ref left, value);
    }

    public double Width
    {
        get => width;
        set => SetProperty(ref width, value);
    }

    public double Height
    {
        get => height;
        set => SetProperty(ref height, value);
    }
}