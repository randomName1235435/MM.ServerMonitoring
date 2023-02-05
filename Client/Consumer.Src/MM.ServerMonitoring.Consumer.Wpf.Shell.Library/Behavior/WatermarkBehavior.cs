using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Behavior;

public class WatermarkBehavior : Behavior<ComboBox>
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(WatermarkBehavior),
            new PropertyMetadata("Watermark"));

    public static readonly DependencyProperty FontSizeProperty =
        DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(WatermarkBehavior),
            new PropertyMetadata(12.0));

    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(WatermarkBehavior),
            new PropertyMetadata(Brushes.Black));

    public static readonly DependencyProperty FontFamilyProperty =
        DependencyProperty.Register(nameof(FontFamily), typeof(string), typeof(WatermarkBehavior),
            new PropertyMetadata("Segoe UI"));

    private WaterMarkAdorner adorner;

    public string Text
    {
        get => (string)this.GetValue(TextProperty);
        set => this.SetValue(TextProperty, value);
    }


    public double FontSize
    {
        get => (double)this.GetValue(FontSizeProperty);
        set => this.SetValue(FontSizeProperty, value);
    }


    public Brush Foreground
    {
        get => (Brush)this.GetValue(ForegroundProperty);
        set => this.SetValue(ForegroundProperty, value);
    }


    public string FontFamily
    {
        get => (string)this.GetValue(FontFamilyProperty);
        set => this.SetValue(FontFamilyProperty, value);
    }


    protected override void OnAttached()
    {
        this.adorner = new WaterMarkAdorner(AssociatedObject, Text, FontSize, FontFamily, Foreground);

        AssociatedObject.Loaded += this.OnLoaded;
        AssociatedObject.GotFocus += this.OnFocus;
        AssociatedObject.LostFocus += this.OnLostFocus;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (!AssociatedObject.IsFocused)
            if (string.IsNullOrEmpty(AssociatedObject.Text))
            {
                var layer = AdornerLayer.GetAdornerLayer(AssociatedObject);
                layer.Add(this.adorner);
            }
    }

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        //if (String.IsNullOrEmpty(this.AssociatedObject.Text))
        //{
        //    try
        //    {
        //        var layer = AdornerLayer.GetAdornerLayer(this.AssociatedObject);
        //        layer.Add(adorner);
        //    }
        //    catch { }
        //}
    }

    private void OnFocus(object sender, RoutedEventArgs e)
    {
        var layer = AdornerLayer.GetAdornerLayer(AssociatedObject);
        layer.Remove(this.adorner);
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
    }

    public class WaterMarkAdorner : Adorner
    {
        private readonly string fontFamily;
        private readonly double fontSize;
        private readonly Brush foreground;
        private readonly string text;

        public WaterMarkAdorner(UIElement element, string text, double fontsize, string font, Brush foreground)
            : base(element)
        {
            IsHitTestVisible = false;
            Opacity = 0.6;
            this.text = text;
            this.fontSize = fontsize;
            this.fontFamily = font;
            this.foreground = foreground;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            var text = new FormattedText(
                this.text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(this.fontFamily), this.fontSize, this.foreground);

            drawingContext.DrawText(text, new Point(3, 3));
        }
    }
}