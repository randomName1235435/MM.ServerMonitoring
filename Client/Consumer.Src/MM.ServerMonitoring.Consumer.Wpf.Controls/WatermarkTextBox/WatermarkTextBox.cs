using System.Windows;
using System.Windows.Controls;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.WatermarkTextBox;

public class WatermarkTextBox : TextBox
{
    public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register(
        nameof(Watermark),
        typeof(object),
        typeof(WatermarkTextBox));

    public static readonly DependencyProperty WatermarkTemplateProperty = DependencyProperty.Register(
        nameof(WatermarkTemplate),
        typeof(DataTemplate),
        typeof(WatermarkTextBox));

    static WatermarkTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBox),
            new FrameworkPropertyMetadata(typeof(WatermarkTextBox)));
    }

    public object Watermark
    {
        get => this.GetValue(WatermarkProperty);
        set => this.SetValue(WatermarkProperty, value);
    }

    public DataTemplate WatermarkTemplate
    {
        get => (DataTemplate)this.GetValue(WatermarkTemplateProperty);
        set => this.SetValue(WatermarkTemplateProperty, value);
    }
}