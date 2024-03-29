﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.Toolbar;

public class BoolInverter : MarkupExtension, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool)
            return !(bool)value;
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return this.Convert(value, targetType, parameter, culture);
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}