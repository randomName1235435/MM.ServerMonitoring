using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.Donutbar;

/// <summary>
///     Interaktionslogik für Donutbar.xaml
/// </summary>
public partial class Donutbar : UserControl
{
    public static readonly DependencyProperty PercentProperty = DependencyProperty.Register(
        "Percent", typeof(double), typeof(Donutbar), new PropertyMetadata());

    public static readonly DependencyProperty ContentColorProperty = DependencyProperty.Register(
        "ContentColor", typeof(Brush), typeof(Donutbar), new PropertyMetadata(Brushes.Red));

    public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register(
        "FillColor", typeof(Brush), typeof(Donutbar), new PropertyMetadata(Brushes.LightGray));

    public static readonly DependencyProperty FontColorProperty = DependencyProperty.Register(
        "FontColor", typeof(Brush), typeof(Donutbar), new PropertyMetadata(Brushes.Gray));

    public static readonly DependencyProperty ArcThicknessProperty = DependencyProperty.Register(
        "ArcThickness", typeof(double), typeof(Donutbar), new PropertyMetadata(5.0));

    public Donutbar()
    {
        this.InitializeComponent();
        //DataContext = this;
    }

    public double Percent
    {
        get => (double)this.GetValue(PercentProperty);
        set => this.SetValue(PercentProperty, value);
    }

    public Brush ContentColor
    {
        get => (Brush)this.GetValue(ContentColorProperty);
        set => this.SetValue(ContentColorProperty, value);
    }

    public Brush FillColor
    {
        get => (Brush)this.GetValue(FillColorProperty);
        set => this.SetValue(FillColorProperty, value);
    }

    public Brush FontColor
    {
        get => (Brush)this.GetValue(FontColorProperty);
        set => this.SetValue(FontColorProperty, value);
    }

    public double ArcThickness
    {
        get => (double)this.GetValue(ArcThicknessProperty);
        set => this.SetValue(FontColorProperty, value);
    }
}