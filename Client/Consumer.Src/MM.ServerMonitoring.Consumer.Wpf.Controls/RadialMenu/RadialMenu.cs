using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.RadialMenu;

internal class RadialMenu : ItemsControl
{
    public static readonly DependencyProperty RadiusProperty;
    public static readonly DependencyProperty InnerRadiusProperty;
    public static readonly DependencyProperty SectorGapProperty;
    public static readonly DependencyProperty GapProperty;
    public static readonly DependencyProperty MenuSectorProperty;
    public static readonly DependencyProperty SelectedBackgroundProperty;
    public static readonly DependencyProperty RotationProperty;
    public static readonly DependencyProperty RotateTextProperty;
    private readonly Selection _selection = new();

    private int _current_level = -1;
    private int _current_selection = -1;

    private List<List<Tuple<double, double>>> _sectors;
    private double _size;
    private bool _was_selected;

    static RadialMenu()
    {
        RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(RadialMenu),
            new FrameworkPropertyMetadata(50.0));
        InnerRadiusProperty = DependencyProperty.Register("InnerRadius", typeof(double), typeof(RadialMenu),
            new FrameworkPropertyMetadata(10.0));
        SectorGapProperty = DependencyProperty.Register("SectorGap", typeof(double), typeof(RadialMenu),
            new FrameworkPropertyMetadata(5.0));
        GapProperty = DependencyProperty.Register("Gap", typeof(double), typeof(RadialMenu),
            new FrameworkPropertyMetadata(5.0));
        MenuSectorProperty = DependencyProperty.Register("MenuSector", typeof(double), typeof(RadialMenu),
            new FrameworkPropertyMetadata(360.0));
        SelectedBackgroundProperty = DependencyProperty.Register("SelectedBackground", typeof(Brush),
            typeof(RadialMenu), new FrameworkPropertyMetadata(Brushes.Gray));
        RotationProperty = DependencyProperty.Register("Rotation", typeof(double), typeof(RadialMenu),
            new FrameworkPropertyMetadata(0.0));
        RotateTextProperty = DependencyProperty.Register("RotateText", typeof(bool), typeof(RadialMenu),
            new FrameworkPropertyMetadata(true));
    }

    [Bindable(true)]
    public double Radius
    {
        get => (double)this.GetValue(RadiusProperty);
        set => this.SetValue(RadiusProperty, value);
    }

    [Bindable(true)]
    public double InnerRadius
    {
        get => (double)this.GetValue(InnerRadiusProperty);
        set => this.SetValue(InnerRadiusProperty, value);
    }

    [Bindable(true)]
    public double SectorGap
    {
        get => (double)this.GetValue(SectorGapProperty);
        set => this.SetValue(SectorGapProperty, value);
    }

    [Bindable(true)]
    public double Gap
    {
        get => (double)this.GetValue(GapProperty);
        set => this.SetValue(GapProperty, value);
    }

    [Bindable(true)]
    public double MenuSector
    {
        get => (double)this.GetValue(MenuSectorProperty);
        set => this.SetValue(MenuSectorProperty, value);
    }

    [Bindable(true)]
    public Brush SelectedBackground
    {
        get => (Brush)this.GetValue(SelectedBackgroundProperty);
        set => this.SetValue(SelectedBackgroundProperty, value);
    }

    [Bindable(true)]
    public double Rotation
    {
        get => (double)this.GetValue(RotationProperty);
        set => this.SetValue(RotationProperty, value);
    }

    [Bindable(true)]
    public bool RotateText
    {
        get => (bool)this.GetValue(RotateTextProperty);
        set => this.SetValue(RotateTextProperty, value);
    }

    protected override Size MeasureOverride(Size availablesize)
    {
        // The "thickness" of each "layer" of menu
        var d = 2.0 * (Radius - InnerRadius + Gap);

        // fictious size of "empty" menu
        var s = 2.0 * (InnerRadius - Gap);

        // find size as maximum size of menu items
        double ss = 0;

        foreach (UIElement i in Items) ss = Math.Max(ss, (i as RadialMenuItem).CalculateSize(s, d));

        foreach (UIElement i in Items) i.Measure(availablesize);

        this._size = ss;

        return new Size(ss, ss);
    }

    protected override Size ArrangeOverride(Size finalsize)
    {
        return finalsize;
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);

        var click_point = e.MouseDevice.GetPosition(this);

        this.Down(click_point);

        e.MouseDevice.Capture(this);

        this.InvalidateVisual();
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonUp(e);

        var point = e.MouseDevice.GetPosition(this);

        this.Up(point);

        // release mouse device
        e.MouseDevice.Capture(null);

        this.InvalidateVisual();
    }

    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.Right)
        {
            this._current_level = 0;
            if (this._current_selection >= this._sectors[0].Count - 1)
                this._current_selection = 0;
            else
                this._current_selection++;
            this._selection.SetSelection(this._current_level, this._current_selection);
        }

        if (e.Key == Key.Left)
        {
            this._current_level = 0;
            if (this._current_selection == 0)
                this._current_selection = this._sectors[0].Count - 1;
            else
                this._current_selection--;
            this._selection.SetSelection(this._current_level, this._current_selection);
        }

        this.InvalidateVisual();
        //base.OnPreviewKeyDown(e);
    }

    protected override void OnTouchDown(TouchEventArgs e)
    {
        base.OnTouchDown(e);
        var touch_point = e.TouchDevice.GetTouchPoint(this).Position;
        this.Down(touch_point);
        e.TouchDevice.Capture(this);
        e.Handled = true;
        this.InvalidateVisual();
    }

    protected override void OnTouchUp(TouchEventArgs e)
    {
        base.OnTouchUp(e);

        var point = e.TouchDevice.GetTouchPoint(this).Position;

        this.Up(point);

        // release touch device
        e.TouchDevice.Capture(null);

        e.Handled = true;

        this.InvalidateVisual();
    }

    private void Down(Point point)
    {
        // find the menu item on which the point is
        var t = this.FindMenuItem(point);
        var level = t.Item1;
        var selection = t.Item2;

        if (selection != -1)
        {
            // remeber the selection
            this._current_level = level;
            this._current_selection = selection;

            if (selection != this._selection.GetSelection(level))
            {
                // select if it is not already selected
                this._selection.SetSelection(level, selection);
                this._was_selected = false;
            }
            else
            {
                // remember that is was already selected
                this._was_selected = true;
            }
        }
    }

    private void Up(Point point)
    {
        if (this._current_level == -1 || this._current_selection == -1) return;

        // find the menu item on which the (release) point is
        var t = this.FindMenuItem(point);
        var level = t.Item1;
        var selection = t.Item2;

        if (level == this._current_level && selection == this._current_selection)
        {
            // release happens in same menu item as the current selection

            // Find menu item and trigger actions
            ItemsControl items_control = this;
            for (var i = 0; i <= level; i++)
            {
                var sel = this._selection.GetSelection(i);

                items_control = (ItemsControl)items_control.Items[sel];
            }

            (items_control as RadialMenuItem).OnClick();

            if (items_control.Items.Count == 0)
                // If no children (means it is a leaf and we have come to our end), then deselect whole menu
                this._selection.SetSelection(0, -1);
            else if (this._was_selected)
                // deselect if it was already selected
                this._selection.SetSelection(level, -1);
        }
        else
        {
            // release happens somewhere else than pressdown

            // Deselect and else do nothing
            this._selection.SetSelection(this._current_level, -1);
        }

        // reset current selection
        this._current_level = -1;
        this._current_selection = -1;
        this._was_selected = false;
    }

    private Tuple<int, int> FindMenuItem(Point point)
    {
        // coordinates of point relative to center
        var x = point.X - this._size / 2.0;
        var y = point.Y - this._size / 2.0;

        // distance from center
        var m = Math.Sqrt(x * x + y * y);

        // find the level in the menu of the part clicked 
        var level = 0;
        var l = Radius;

        // a small buffer just to avoid getting a level that is not there
        var g = Gap > 0 ? Gap / 2.0 : 1;
        while (m >= l + g)
        {
            level++;
            l += Gap + Radius - InnerRadius;
        }

        if (level >= this._sectors.Count)
            // point is outside higest level of visible menu
            return new Tuple<int, int>(-1, -1);

        // angle in radians
        var theta = Math.Acos(Math.Abs(x / m));

        // convert angle to degrees
        double angle = 0;
        if (x >= 0 && y >= 0) angle = theta * (360.0 / (2.0 * Math.PI));
        else if (x >= 0 && y < 0) angle = 360.0 - theta * (360.0 / (2.0 * Math.PI));
        else if (x < 0 && y >= 0) angle = 180.0 - theta * (360.0 / (2.0 * Math.PI));
        else if (x < 0 && y < 0) angle = 180 + theta * (360.0 / (2.0 * Math.PI));

        // run through the visible sectors at present level to see in which sector the angle belongs
        // must consider the possibility that angles defining sectors might be less that 0 and greater than 360
        // if rotation is less than -180 or greater than 360 there may be some problems, but this is handled in initial call to DrawMenu

        var selection = -1;

        for (var i = 0; i < this._sectors[level].Count; i++)
        {
            var a1 = this._sectors[level][i].Item1;
            var a2 = this._sectors[level][i].Item2;

            // we have as invariant a1 < a2

            if (a1 < 0.0 && a2 >= 0.0)
            {
                if (a1 + 360.0 <= angle || angle <= a2)
                {
                    selection = i;
                    break;
                }
            }
            else if (a1 < 0.0 && a2 < 0.0)
            {
                if (a1 + 360.0 <= angle && angle <= a2 + 360.0)
                {
                    selection = i;
                    break;
                }
            }
            else if (a1 > 360.0)
            {
                if (a1 - 360.0 <= angle && angle <= a2 - 360.0)
                {
                    selection = i;
                    break;
                }
            }
            else if (a2 > 360.0) // Must have: 0.0 <= a1 <= 360.0
            {
                if (a1 <= angle || angle <= a2 - 360.0)
                {
                    selection = i;
                    break;
                }
            }
            else // 0.0 <= a1 <= 360.0 && 0.0 <= a2 <= 360.0
            {
                if (a1 <= angle && angle <= a2)
                {
                    selection = i;
                    break;
                }
            }
        }

        return new Tuple<int, int>(level, selection);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        // "normalize" rotation to avoid problems elsewhere
        var rotation = Rotation;
        while (rotation < 0.0) rotation += 360.0;
        while (rotation > 360.0) rotation -= 360.0;

        // initialize data structure for remembering sectors at each level
        this._sectors = new List<List<Tuple<double, double>>>();

        // Draw the menu (level 0)
        this.DrawMenu(this, 0, rotation, MenuSector, drawingContext);
    }

    private void DrawMenu(ItemsControl items_control, int level, double angle, double sector,
        DrawingContext drawingContext)
    {
        // Make sure sector is no more than 360 degrees
        var full_sector = Math.Min(sector, 360.0);

        // find number of menu items at current level
        // return if none
        var count = items_control.Items.Count;
        if (count == 0) return;

        // Add list to remember sectors at this level
        this._sectors.Add(new List<Tuple<double, double>>());

        // Coordinates of center of (full) menu
        var x = this._size / 2.0;
        var y = this._size / 2.0;

        // calculate inner and outer radius for this level
        var inner_radius = InnerRadius + (Radius - InnerRadius + Gap) * level;
        if (inner_radius < SectorGap) inner_radius = SectorGap;
        var outer_radius = Radius + (Radius - InnerRadius + Gap) * level;

        // Sector gap is given as a length. Find the angle giving this gap on inner and outer radius
        double inner_gap_angle;
        if (inner_radius == 0) inner_gap_angle = 0;
        else inner_gap_angle = 2.0 * Math.Asin(SectorGap / (2.0 * inner_radius)) * 360.0 / (2.0 * Math.PI);
        var outer_gap_angle = 2.0 * Math.Asin(SectorGap / (2.0 * outer_radius)) * 360.0 / (2.0 * Math.PI);

        // numbers of sector gaps (one more if we are using full circle)
        var c = full_sector < 360.0 ? count - 1 : count;

        // Calculate the inner and outer arc of each menu item
        var inner_angle = (full_sector - inner_gap_angle * c) / count;
        var outer_angle = (full_sector - outer_gap_angle * c) / count;

        // draw each menu item 
        for (var i = 0; i < count; i++)
        {
            // calculate the boundaries of menu item as angle of the inner and outer arcs
            var start_inner_angle = angle + i * (full_sector / count) + inner_gap_angle / 2.0;
            var end_inner_angle = start_inner_angle + full_sector / count - inner_gap_angle;
            var start_outer_angle = angle + i * (full_sector / count) + outer_gap_angle / 2.0;
            var end_outer_angle = start_outer_angle + full_sector / count - outer_gap_angle;

            // remeber the boundaries (as sector angles) of the menu item
            this._sectors[level].Add(new Tuple<double, double>(start_outer_angle, end_outer_angle));

            // Calculate the corners of the sector
            var p1 = this.CalculatePoint(x, y, start_inner_angle, inner_radius);
            var p2 = this.CalculatePoint(x, y, end_inner_angle, inner_radius);
            var p3 = this.CalculatePoint(x, y, end_outer_angle, outer_radius);
            var p4 = this.CalculatePoint(x, y, start_outer_angle, outer_radius);

            // find center of the corners 
            var center = this.CalculatePoint(x, y, (start_inner_angle + end_inner_angle) / 2.0,
                (inner_radius + outer_radius) / 2.0);

            // specify the figure representing the menu item
            var pathFigure = new PathFigure();
            pathFigure.Segments = new PathSegmentCollection();
            pathFigure.StartPoint = p1;
            pathFigure.Segments.Add(new ArcSegment(p2, new Size(inner_radius, inner_radius),
                end_inner_angle - start_inner_angle, end_inner_angle - start_inner_angle > 180.0,
                SweepDirection.Clockwise, true));
            pathFigure.Segments.Add(new LineSegment(p3, true));
            pathFigure.Segments.Add(new ArcSegment(p4, new Size(outer_radius, outer_radius),
                end_outer_angle - start_outer_angle, end_outer_angle - start_outer_angle > 180.0,
                SweepDirection.Counterclockwise, true));
            pathFigure.IsClosed = true;
            pathFigure.IsFilled = true;

            // Create geometry object and add the figure
            var geometry = new PathGeometry();
            geometry.Figures.Add(pathFigure);

            // Get the menu item to extract properties
            var menu_item = items_control.Items[i] as RadialMenuItem;

            // find color for backgound and border 
            var background_brush = menu_item.Background;
            if (background_brush == null) background_brush = Background;
            if (background_brush == null) background_brush = Brushes.White;

            if (this._selection.GetSelection(level) == i) background_brush = SelectedBackground;

            var border_brush = menu_item.BorderBrush;
            if (border_brush == null) border_brush = BorderBrush;

            // Draw the geometry representing the menu item
            drawingContext.DrawGeometry(background_brush, new Pen(border_brush, menu_item.BorderThickness.Left),
                geometry);

            // Get header of menu item as string and make a formatted text based on properties of menu item
            var header = (string)menu_item.Header;

            var text = new FormattedText(header,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(menu_item.FontFamily, menu_item.FontStyle, menu_item.FontWeight, menu_item.FontStretch),
                menu_item.FontSize,
                menu_item.Foreground);

            // Calculate placement of text
            var text_point = new Point(center.X - text.Width / 2.0, center.Y - text.Height / 2.0);

            // Draw the text as name of menu item
            if (RotateText)
                drawingContext.PushTransform(new RotateTransform((start_inner_angle + end_inner_angle) / 2.0 + 90.0,
                    center.X, center.Y));
            drawingContext.DrawText(text, text_point);
            if (RotateText) drawingContext.Pop();

            // if this menu item is selected, draw the next level
            if (this._selection.GetSelection(level) == i)
            {
                // start angle of sub menu is center angle of menu item minus half the sector of the sub menu
                var new_angle = (start_inner_angle + end_inner_angle) / 2.0 - menu_item.SubMenuSector / 2.0;
                this.DrawMenu(menu_item, level + 1, new_angle, menu_item.SubMenuSector, drawingContext);
            }
        }
    }

    private Point CalculatePoint(double centerX, double centerY, double angle, double radius)
    {
        var x = centerX + Math.Cos(Math.PI / 180.0 * angle) * radius;
        var y = centerY + Math.Sin(Math.PI / 180.0 * angle) * radius;
        return new Point(x, y);
    }
}