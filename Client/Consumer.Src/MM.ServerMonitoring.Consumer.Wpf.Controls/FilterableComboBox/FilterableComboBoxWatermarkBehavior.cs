using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.FilterableComboBox;

public class FilterableComboBoxWatermarkBehavior : Behavior<FilterableComboBox>
{
    public static readonly DependencyProperty WatermarkProperty =
        DependencyProperty.Register(nameof(Watermark), typeof(string), typeof(FilterableComboBoxWatermarkBehavior),
            new PropertyMetadata("Watermark"));


    public static readonly DependencyProperty FontSizeProperty =
        DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(FilterableComboBoxWatermarkBehavior),
            new PropertyMetadata(12.0));


    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(FilterableComboBoxWatermarkBehavior),
            new PropertyMetadata(Brushes.Black));


    public static readonly DependencyProperty FontFamilyProperty =
        DependencyProperty.Register(nameof(FontFamily), typeof(string), typeof(FilterableComboBoxWatermarkBehavior),
            new PropertyMetadata("Segoe UI"));

    public static readonly DependencyProperty MarginProperty =
        DependencyProperty.Register(nameof(Margin), typeof(Thickness), typeof(FilterableComboBoxWatermarkBehavior));

    private FilterableComboBoxWaterMarkAdorner adorner;

    public string Watermark
    {
        get => (string)this.GetValue(WatermarkProperty);
        set => this.SetValue(WatermarkProperty, value);
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


    public Thickness Margin
    {
        get => (Thickness)this.GetValue(MarginProperty);
        set => this.SetValue(MarginProperty, value);
    }


    protected override void OnAttached()
    {
        this.adorner =
            new FilterableComboBoxWaterMarkAdorner(AssociatedObject, Watermark, FontSize, FontFamily, Margin,
                Foreground);

        AssociatedObject.Loaded += this.OnLoaded;
        AssociatedObject.GotFocus += this.OnFocus;
        AssociatedObject.LostFocus += this.OnLostFocus;
        AssociatedObject.SelectionChanged += this.OnSelectionChange;
    }

    private void OnSelectionChange(object sender, SelectionChangedEventArgs e)
    {
        if (AssociatedObject.SelectedItem == null)
        {
            this.AddWatermark();
            return;
        }

        this.RemoveWatermark();
    }

    private void RemoveWatermark()
    {
        var layer = AdornerLayer.GetAdornerLayer(AssociatedObject);
        layer?.Remove(this.adorner);
    }

    private void ReplaceWatermark()
    {
        if (string.IsNullOrEmpty(AssociatedObject.Text))
            try
            {
                var layer = AdornerLayer.GetAdornerLayer(AssociatedObject);
                var adorners = layer.GetAdorners(AssociatedObject);
                if (adorners != null)
                    foreach (var adorner in adorners)
                        layer.Remove(adorner);

                layer.Add(this.adorner);
            }
            catch
            {
            }
    }

    private void AddWatermark()
    {
        if (!AssociatedObject.IsFocused)
            if (string.IsNullOrEmpty(AssociatedObject.Text))
            {
                var layer = AdornerLayer.GetAdornerLayer(AssociatedObject);
                layer.Add(this.adorner);
            }
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        this.AddWatermark();
    }

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        this.ReplaceWatermark();
    }

    private void OnFocus(object sender, RoutedEventArgs e)
    {
        this.RemoveWatermark();
    }

    public class FilterableComboBoxWaterMarkAdorner : Adorner
    {
        private readonly string fontFamily;
        private readonly double fontSize;
        private readonly Brush foreground;
        private readonly string text;

        public FilterableComboBoxWaterMarkAdorner(UIElement element, string text, double fontsize, string font,
            Thickness margin,
            Brush foreground)
            : base(element)
        {
            IsHitTestVisible = false;
            Opacity = 0.6;
            this.text = text;
            this.fontSize = fontsize;
            this.fontFamily = font;
            this.foreground = foreground;
            Margin = margin;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var m = PresentationSource.FromVisual(Application.Current.MainWindow).CompositionTarget.TransformToDevice;

            var text = new FormattedText(
                this.text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(this.fontFamily),
                this.fontSize,
                this.foreground, m.M11);

            drawingContext.DrawText(text, new Point(3, 3));
        }
    }
}