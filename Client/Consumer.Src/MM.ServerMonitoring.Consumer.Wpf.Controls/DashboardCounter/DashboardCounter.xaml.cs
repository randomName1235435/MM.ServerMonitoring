using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.DashboardCounter;

/// <summary>
///     Interaktionslogik für DashboardCounter.xaml
/// </summary>
public partial class DashboardCounter : UserControl
{
    public static readonly DependencyProperty LabelProjectsLeisteZahlStyleProperty = DependencyProperty.Register(
        nameof(LabelProjectsLeisteZahlStyle), typeof(Style), typeof(DashboardCounter),
        new PropertyMetadata(default(Style)));

    public static readonly DependencyProperty LabelProjectsLeisteTextStyleProperty = DependencyProperty.Register(
        nameof(LabelProjectsLeisteTextStyle), typeof(Style), typeof(DashboardCounter),
        new PropertyMetadata(default(Style)));

    public static readonly DependencyProperty RectangleBrushProperty = DependencyProperty.Register(
        nameof(RectangleBrush), typeof(Brush), typeof(DashboardCounter), new PropertyMetadata(default(Brush)));

    public static readonly DependencyProperty CounterProperty = DependencyProperty.Register(
        nameof(Counter), typeof(string), typeof(DashboardCounter),
        new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty CounterTextProperty = DependencyProperty.Register(
        nameof(CounterText), typeof(string), typeof(DashboardCounter), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
        nameof(Command), typeof(ICommand), typeof(DashboardCounter), new PropertyMetadata(default(ICommand)));

    public DashboardCounter()
    {
        this.InitializeComponent();
    }

    public Style LabelProjectsLeisteZahlStyle
    {
        get => (Style)this.GetValue(LabelProjectsLeisteZahlStyleProperty);
        set => this.SetValue(LabelProjectsLeisteZahlStyleProperty, value);
    }

    public Style LabelProjectsLeisteTextStyle
    {
        get => (Style)this.GetValue(LabelProjectsLeisteTextStyleProperty);
        set => this.SetValue(LabelProjectsLeisteTextStyleProperty, value);
    }

    public Brush RectangleBrush
    {
        get => (Brush)this.GetValue(RectangleBrushProperty);
        set => this.SetValue(RectangleBrushProperty, value);
    }

    public string Counter
    {
        get => (string)this.GetValue(CounterProperty);
        set => this.SetValue(CounterProperty, value);
    }

    public string CounterText
    {
        get => (string)this.GetValue(CounterTextProperty);
        set => this.SetValue(CounterTextProperty, value);
    }

    public ICommand Command
    {
        get => (ICommand)this.GetValue(CommandProperty);
        set => this.SetValue(CommandProperty, value);
    }

    private void DashboardCounter_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (Command != null && Command.CanExecute(null)) Command.Execute(null);
    }
}