using System.Windows;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Extensions;

/// <summary>
///     cause we cant bind startupLocation from mainWindow, cause no dependency prop
/// </summary>
public static class WindowStartupExtension
{
    public static readonly DependencyProperty WindowStartupLocationProperty;

    static WindowStartupExtension()
    {
        WindowStartupLocationProperty = DependencyProperty.RegisterAttached("WindowStartupLocation",
            typeof(WindowStartupLocation),
            typeof(WindowStartupExtension),
            new UIPropertyMetadata(WindowStartupLocation.Manual, OnWindowStartupLocationChanged));
    }

    public static void SetWindowStartupLocation(DependencyObject DepObject, WindowStartupLocation value)
    {
        DepObject.SetValue(WindowStartupLocationProperty, value);
    }

    public static WindowStartupLocation GetWindowStartupLocation(DependencyObject DepObject)
    {
        return (WindowStartupLocation)DepObject.GetValue(WindowStartupLocationProperty);
    }

    private static void OnWindowStartupLocationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var window = sender as Window;

        if (window != null) window.WindowStartupLocation = GetWindowStartupLocation(window);
    }
}