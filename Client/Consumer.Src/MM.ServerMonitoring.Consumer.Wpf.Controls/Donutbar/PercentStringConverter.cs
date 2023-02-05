using System;
using System.Globalization;
using System.Windows.Data;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.Donutbar;

public class PercentStringConverter : IValueConverter
{
    public object Convert(object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return value + "%";
    }

    public object ConvertBack(object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return 0.0;
    }
}