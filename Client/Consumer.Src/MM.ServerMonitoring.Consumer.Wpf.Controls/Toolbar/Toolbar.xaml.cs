using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.Toolbar;

/// <summary>
///     Interaktionslogik für Toolbar.xaml
/// </summary>
public partial class Toolbar : UserControl
{
    public static readonly DependencyProperty LoadCommandVisibilityProperty = DependencyProperty.Register(
        nameof(LoadCommandVisibility), typeof(Visibility), typeof(Toolbar), new PropertyMetadata(default(Visibility)));

    public static readonly DependencyProperty FilterCommandVisibilityProperty = DependencyProperty.Register(
        nameof(FilterCommandVisibility), typeof(Visibility), typeof(Toolbar),
        new PropertyMetadata(default(Visibility)));

    public static readonly DependencyProperty CreateCommandVisibilityProperty = DependencyProperty.Register(
        nameof(CreateCommandVisibility), typeof(Visibility), typeof(Toolbar),
        new PropertyMetadata(default(Visibility)));

    public static readonly DependencyProperty DeleteCommandVisibilityProperty = DependencyProperty.Register(
        nameof(DeleteCommandVisibility), typeof(Visibility), typeof(Toolbar),
        new PropertyMetadata(default(Visibility)));

    public static readonly DependencyProperty UpdateCommandVisibilityProperty = DependencyProperty.Register(
        nameof(UpdateCommandVisibility), typeof(Visibility), typeof(Toolbar),
        new PropertyMetadata(default(Visibility)));

    public static readonly DependencyProperty CreateCommandProperty = DependencyProperty.Register(
        nameof(CreateCommand), typeof(ICommand), typeof(Toolbar), new PropertyMetadata(default(ICommand)));

    public static readonly DependencyProperty FilterCommandProperty = DependencyProperty.Register(
        nameof(FilterCommand), typeof(ICommand), typeof(Toolbar), new PropertyMetadata(default(ICommand)));

    public static readonly DependencyProperty FilterCommandParameterProperty = DependencyProperty.Register(
        nameof(FilterCommandParameter), typeof(object), typeof(Toolbar), new PropertyMetadata(null));

    public static readonly DependencyProperty CreateCommandParameterProperty = DependencyProperty.Register(
        nameof(CreateCommandParameter), typeof(object), typeof(Toolbar), new PropertyMetadata(null));

    public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
        nameof(DeleteCommand), typeof(ICommand), typeof(Toolbar), new PropertyMetadata(default(ICommand)));

    public static readonly DependencyProperty UpdateCommandProperty = DependencyProperty.Register(
        nameof(UpdateCommand), typeof(ICommand), typeof(Toolbar), new PropertyMetadata(default(ICommand)));

    public static readonly DependencyProperty DeleteCommandParameterProperty = DependencyProperty.Register(
        nameof(DeleteCommandParameter), typeof(object), typeof(Toolbar), new PropertyMetadata(null));

    public static readonly DependencyProperty UpdateCommandParameterProperty = DependencyProperty.Register(
        nameof(UpdateCommandParameter), typeof(object), typeof(Toolbar), new PropertyMetadata(null));

    public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register(
        nameof(ButtonStyle), typeof(Style), typeof(Toolbar), new PropertyMetadata(default(Style)));

    public static readonly DependencyProperty ToggleButtonStyleProperty = DependencyProperty.Register(
        nameof(ToggleButtonStyle), typeof(Style), typeof(Toolbar), new PropertyMetadata(default(Style)));

    public static readonly DependencyProperty WatermarkTextBoxStyleProperty = DependencyProperty.Register(
        nameof(WatermarkTextBoxStyle), typeof(Style), typeof(Toolbar), new PropertyMetadata(default(Style)));

    public Toolbar()
    {
        this.InitializeComponent();
    }

    public Visibility LoadCommandVisibility
    {
        get => (Visibility)this.GetValue(LoadCommandVisibilityProperty);
        set => this.SetValue(LoadCommandVisibilityProperty, value);
    }

    public Visibility FilterCommandVisibility
    {
        get => (Visibility)this.GetValue(FilterCommandVisibilityProperty);
        set => this.SetValue(FilterCommandVisibilityProperty, value);
    }

    public Visibility CreateCommandVisibility
    {
        get => (Visibility)this.GetValue(CreateCommandVisibilityProperty);
        set => this.SetValue(CreateCommandVisibilityProperty, value);
    }

    public Visibility DeleteCommandVisibility
    {
        get => (Visibility)this.GetValue(DeleteCommandVisibilityProperty);
        set => this.SetValue(DeleteCommandVisibilityProperty, value);
    }

    public Visibility UpdateCommandVisibility
    {
        get => (Visibility)this.GetValue(UpdateCommandVisibilityProperty);
        set => this.SetValue(UpdateCommandVisibilityProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => (ICommand)this.GetValue(DeleteCommandProperty);
        set => this.SetValue(DeleteCommandProperty, value);
    }

    public ICommand FilterCommand
    {
        get => (ICommand)this.GetValue(FilterCommandProperty);
        set => this.SetValue(FilterCommandProperty, value);
    }

    public object FilterCommandParameter
    {
        get => (object)this.GetValue(FilterCommandProperty);
        set => this.SetValue(FilterCommandProperty, value);
    }

    public ICommand UpdateCommand
    {
        get => (ICommand)this.GetValue(UpdateCommandProperty);
        set => this.SetValue(UpdateCommandProperty, value);
    }

    public object DeleteCommandParameter
    {
        get => this.GetValue(DeleteCommandParameterProperty);
        set => this.SetValue(DeleteCommandParameterProperty, value);
    }

    public object UpdateCommandParameter
    {
        get => (object)this.GetValue(UpdateCommandParameterProperty);
        set => this.SetValue(UpdateCommandParameterProperty, value);
    }

    public object CreateCommandParameter
    {
        get => (object)this.GetValue(CreateCommandParameterProperty);
        set => this.SetValue(CreateCommandParameterProperty, value);
    }


    public Style ToggleButtonStyle
    {
        get => (Style)this.GetValue(ToggleButtonStyleProperty);
        set => this.SetValue(ToggleButtonStyleProperty, value);
    }

    public Style WatermarkTextBoxStyle
    {
        get => (Style)this.GetValue(WatermarkTextBoxStyleProperty);
        set => this.SetValue(WatermarkTextBoxStyleProperty, value);
    }

    public ICommand CreateCommand
    {
        get => (ICommand)this.GetValue(CreateCommandProperty);
        set => this.SetValue(CreateCommandProperty, value);
    }

    public Style ButtonStyle
    {
        get => (Style)this.GetValue(ButtonStyleProperty);
        set => this.SetValue(ButtonStyleProperty, value);
    }
}