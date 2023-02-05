using System;
using System.Globalization;
using System.Windows.Data;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.Donutbar;

public class PercentageConverter : IValueConverter
{
    public object Convert(object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        double outParam;
        if (double.TryParse(value.ToString(), out outParam))
        {
            if (outParam > 100) return (double)0;
            return 360 - outParam * System.Convert.ToDouble(3.6);
        }

        return (double)0;
    }

    public object ConvertBack(object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return 0.0;
    }
}