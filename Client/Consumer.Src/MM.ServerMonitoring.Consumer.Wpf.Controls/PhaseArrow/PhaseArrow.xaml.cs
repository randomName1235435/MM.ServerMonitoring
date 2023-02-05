using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.PhaseArrow;

public partial class PhaseArrow : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(PhaseArrow), new PropertyMetadata(""));

    public static readonly DependencyProperty ArrowBrushProperty =
        DependencyProperty.Register("ArrowBrush", typeof(Brush), typeof(PhaseArrow),
            new PropertyMetadata(Brushes.Transparent));

    public PhaseArrow()
    {
        this.InitializeComponent();
    }

    public string Text
    {
        get => (string)this.GetValue(TextProperty);
        set => this.SetValue(TextProperty, value);
    }

    public Brush ArrowBrush
    {
        get => (Brush)this.GetValue(ArrowBrushProperty);
        set => this.SetValue(ArrowBrushProperty, value);
    }
}