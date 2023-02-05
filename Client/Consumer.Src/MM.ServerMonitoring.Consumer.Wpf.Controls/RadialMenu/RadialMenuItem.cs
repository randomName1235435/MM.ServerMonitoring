using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.RadialMenu;

internal class RadialMenuItem : HeaderedItemsControl
{
    public static readonly DependencyProperty SubMenuSectorProperty;
    public static readonly DependencyProperty CommandProperty;

    private double _size;

    static RadialMenuItem()
    {
        SubMenuSectorProperty = DependencyProperty.Register("SubMenuSector", typeof(double), typeof(RadialMenuItem),
            new FrameworkPropertyMetadata(120.0));
        CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(RadialMenuItem),
            new FrameworkPropertyMetadata(null));
    }

    [Bindable(true)]
    public double SubMenuSector
    {
        get => (double)this.GetValue(SubMenuSectorProperty);
        set => this.SetValue(SubMenuSectorProperty, value);
    }

    [Bindable(true)]
    public ICommand Command
    {
        get => (ICommand)this.GetValue(CommandProperty);
        set => this.SetValue(CommandProperty, value);
    }

    public event RoutedEventHandler Click;

    public double CalculateSize(double s, double d)
    {
        // size of current level 
        var ss = s + d;

        foreach (UIElement i in Items)
            if (i is RadialMenuItem radialMenuItem)
                ss = Math.Max(ss, radialMenuItem.CalculateSize(s + d, d));

        this._size = ss;

        return this._size;
    }

    protected override Size MeasureOverride(Size availablesize)
    {
        foreach (UIElement i in Items) i.Measure(availablesize);

        return new Size(this._size, this._size);
    }

    protected override Size ArrangeOverride(Size finalsize)
    {
        return finalsize;
    }

    public void OnClick()
    {
        if (Command != null && Command.CanExecute(null)) Command.Execute(Header);

        if (Click != null) Click(this, new RoutedEventArgs());
    }
}