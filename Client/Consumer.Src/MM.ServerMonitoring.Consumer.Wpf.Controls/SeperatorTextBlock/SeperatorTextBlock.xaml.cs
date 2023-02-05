using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.SeperatorTextBlock;

public partial class SeperatorTextBlock : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(SeperatorTextBlock), new PropertyMetadata("Test"));

    public static readonly DependencyProperty SeperatorTextProperty =
        DependencyProperty.Register("SeperatorText", typeof(string), typeof(SeperatorTextBlock),
            new PropertyMetadata("-"));

    public static readonly DependencyProperty SeperatorVisibilityProperty = DependencyProperty.Register(
        "SeperatorVisibility", typeof(Visibility), typeof(SeperatorTextBlock),
        new PropertyMetadata(Visibility.Visible));

    public static readonly DependencyProperty SeperatorBrushProperty = DependencyProperty.Register(
        "SeperatorBrush", typeof(SolidColorBrush), typeof(SeperatorTextBlock), new PropertyMetadata(default(Brush)));

    public static readonly DependencyProperty TextBackgroundProperty = DependencyProperty.Register(
        "TextBackground", typeof(SolidColorBrush), typeof(SeperatorTextBlock),
        new PropertyMetadata(default(SolidColorBrush)));

    public static readonly DependencyProperty TextForeGroundProperty = DependencyProperty.Register(
        "TextForeGround", typeof(SolidColorBrush), typeof(SeperatorTextBlock),
        new PropertyMetadata(default(SolidColorBrush)));

    public static readonly DependencyProperty TextFontWeightProperty = DependencyProperty.Register(
        "TextFontWeight", typeof(FontWeight), typeof(SeperatorTextBlock), new PropertyMetadata(default(FontWeight)));

    public SeperatorTextBlock()
    {
        this.InitializeComponent();
    }

    public string Text
    {
        get => (string)this.GetValue(TextProperty);
        set => this.SetValue(TextProperty, value);
    }

    public string SeperatorText
    {
        get => (string)this.GetValue(SeperatorTextProperty);
        set => this.SetValue(SeperatorTextProperty, value);
    }

    public Visibility SeperatorVisibility
    {
        get => (Visibility)this.GetValue(SeperatorVisibilityProperty);
        set => this.SetValue(SeperatorVisibilityProperty, value);
    }

    public SolidColorBrush SeperatorBrush
    {
        get => (SolidColorBrush)this.GetValue(SeperatorBrushProperty);
        set => this.SetValue(SeperatorBrushProperty, value);
    }

    public SolidColorBrush TextBackground
    {
        get => (SolidColorBrush)this.GetValue(TextBackgroundProperty);
        set => this.SetValue(TextBackgroundProperty, value);
    }

    public SolidColorBrush TextForeGround
    {
        get => (SolidColorBrush)this.GetValue(TextForeGroundProperty);
        set => this.SetValue(TextForeGroundProperty, value);
    }

    public FontWeight TextFontWeight
    {
        get => (FontWeight)this.GetValue(TextFontWeightProperty);
        set => this.SetValue(TextFontWeightProperty, value);
    }
}