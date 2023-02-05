using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MM.ServerMonitoring.Consumer.Wpf.Controls.PhaseControl;

public partial class PhaseControl : UserControl
{
    public static readonly DependencyProperty ItemListProperty = DependencyProperty.Register(
        "ItemList", typeof(ObservableCollection<int>), typeof(PhaseControl),
        new PropertyMetadata(new ObservableCollection<int>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30
        }));


    public PhaseControl()
    {
        ItemList = new ObservableCollection<int>();
        MinDatum = DateTime.MinValue;
        MaxDatum = DateTime.MinValue;
        this.InitializeComponent();

        EndPlanung = DateTime.Now;
        EndDesign = DateTime.Now;
        EndEntwicklung = DateTime.Now;
        EndTest = DateTime.Now;
        EndBetrieb = DateTime.Now;
    }

    public DateTime MinDatum { get; set; }
    public DateTime MaxDatum { get; set; }
    public DateTime EndPlanung { get; set; }
    public DateTime EndDesign { get; set; }
    public DateTime EndEntwicklung { get; set; }
    public DateTime EndTest { get; set; }
    public DateTime EndBetrieb { get; set; }

    public PhaseArrow.PhaseArrow PlanungsRect => this.planungRect;
    public PhaseArrow.PhaseArrow DesignRect => this.designRect;
    public PhaseArrow.PhaseArrow EntwicklungRect => this.entwicklungRect;
    public PhaseArrow.PhaseArrow TestRect => this.testRect;
    public PhaseArrow.PhaseArrow BetriebRect => this.betriebRect;

    public ObservableCollection<int> ItemList
    {
        get => (ObservableCollection<int>)this.GetValue(ItemListProperty);
        set => this.SetValue(ItemListProperty, value);
    }
    //public Project Project
    //{
    //    get { return (Project)GetValue(ProjectProperty); }
    //    set { SetValue(ProjectProperty, value); }
    //}

    //public static readonly DependencyProperty ProjectProperty = DependencyProperty.Register(
    //    "Project", typeof(Project), typeof(PhaseControl), new PropertyMetadata(new Project(), OnProjectChanged));


    private static void OnProjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (PhaseControl)d;
        if (e.NewValue == null) return;
        control.ItemList = new ObservableCollection<int>();

        //var project = (Project)e.NewValue;
        //if (project.StartPlanung == null)
        //{
        //    control.Reset();
        //    return;
        //}

        //control.MinDatum = project.StartPlanung.Value;
        //control.MaxDatum = GetMaxDatum(project);

        //control.PositioningRectangle(control.PlanungsRect, project.StartPlanung, project.StartDesign == null ? (DateTime?)null : project.StartDesign.Value.AddDays(-1));
        //control.PositioningRectangle(control.DesignRect, project.StartDesign, project.StartEntwicklung == null ? (DateTime?)null : project.StartEntwicklung.Value.AddDays(-1));
        //control.PositioningRectangle(control.EntwicklungRect, project.StartEntwicklung, project.StartTest == null ? (DateTime?)null : project.StartTest.Value.AddDays(-1));
        //control.PositioningRectangle(control.TestRect, project.StartTest, project.StartBetrieb == null ? (DateTime?)null : project.StartBetrieb.Value.AddDays(-1));
        //control.PositioningRectangle(control.BetriebRect, project.StartBetrieb, DateTime.Now);

        control.FillDays(control.MinDatum, control.MaxDatum);
    }

    private void Reset()
    {
        PlanungsRect.Visibility = Visibility.Collapsed;
        DesignRect.Visibility = Visibility.Collapsed;
        EntwicklungRect.Visibility = Visibility.Collapsed;
        TestRect.Visibility = Visibility.Collapsed;
        BetriebRect.Visibility = Visibility.Collapsed;
    }

    private void FillDays(DateTime start, DateTime end)
    {
        while (start.AddDays(-1).Date < end.Date)
        {
            ItemList.Add(start.Day);
            start = start.AddDays(1);
        }

        var width = ActualWidth;
        while (width - ItemList.Count * 17 > 0)
        {
            ItemList.Add(start.Day);
            start = start.AddDays(1);
        }
    }

    private void PositioningRectangle(PhaseArrow.PhaseArrow rectangle, DateTime? start, DateTime? end)
    {
        if (start == null) return;

        rectangle.Height = 50;
        rectangle.HorizontalAlignment = HorizontalAlignment.Left;
        rectangle.Visibility = Visibility.Visible;
        var offset = (start - MinDatum).Value.Days;
        rectangle.Margin = new Thickness(1 + offset * 22, 0, 0, 0);
        if (end.HasValue)
        {
            var width = (end - start).Value.Days * 22;
            rectangle.Width = width < 0 ? 0 : width;
        }

        else
        {
            rectangle.Width = (DateTime.Today - start.Value).Days * 22;
        }
    }

    //private static DateTime GetMaxDatum(Project project)
    //{
    //    if (project.StartBetrieb.HasValue)
    //        return project.StartBetrieb.Value;
    //    if (project.StartTest.HasValue)
    //        return project.StartTest.Value;
    //    if (project.StartEntwicklung.HasValue)
    //        return project.StartEntwicklung.Value;
    //    if (project.StartDesign.HasValue)
    //        return project.StartDesign.Value;
    //    if (project.StartPlanung.HasValue)
    //        return project.StartPlanung.Value;
    //    return DateTime.Now;
    //}

    private static void OnStartDesignChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        //var control = (PhaseControl)d;
        //if (e.NewValue == null) return;

        //if (control.MaxDatum < (DateTime)e.NewValue)
        //    control.MaxDatum = (DateTime)e.NewValue;


        //control.planungRect.Width = (control.StartDatumEntwicklung.Value.AddDays(-1) - control.StartDatumPlanung.Value).Days * 22;


        //control.EndPlanung = (DateTime.Parse((string)e.NewValue).AddDays(-1));
        ////fake
        //control.EndDesign = (DateTime.Parse((string)e.NewValue).AddDays(+10));
        //control.MaxDatum = control.EndDesign;


        //var totalDay = control.EndDesign - control.StartDatumPlanung;
        //var currentDate = control.MinDatum;
        //while (currentDate.AddDays(-1) < control.MaxDatum)
        //{
        //    control.ItemList.Add(currentDate.Day);
        //    currentDate = currentDate.AddDays(1);
        //}


        //Rectangle rectangle2 = new Rectangle();
        //rectangle2.Height = 100;
        //rectangle2.Fill = Brushes.Red;
        //rectangle2.HorizontalAlignment = HorizontalAlignment.Left;
        //var days = (control.StartDatumDesign - control.MinDatum).Value.Days - 1;
        //rectangle2.Margin = new Thickness(1 + days * 22, 0, 0, 0);
        //rectangle2.Width = (control.EndDesign - control.StartDatumDesign).Value.Days * 22;
        //control.Grid.Children.Add(rectangle2);

        //Rectangle rectangle3 = new Rectangle();
        //rectangle3.Height = 100;
        //rectangle3.Fill = Brushes.Red;
        //rectangle3.HorizontalAlignment = HorizontalAlignment.Left;
        //days = (control.StartDatumEntwicklung - control.MinDatum).Value.Days - 1;
        //rectangle3.Margin = new Thickness(1 + days * 22, 0, 0, 0);
        //rectangle3.Width = (control.EndEntwicklung - control.StartDatumEntwicklung).Value.Days * 22;
        //control.Grid.Children.Add(rectangle3);

        //Rectangle rectangle4 = new Rectangle();
        //rectangle4.Height = 100;
        //rectangle4.Fill = Brushes.Red;
        //rectangle4.HorizontalAlignment = HorizontalAlignment.Left;
        //days = (control.StartDatumTest - control.MinDatum).Value.Days - 1;
        //rectangle4.Margin = new Thickness(1 + days * 22, 0, 0, 0);
        //rectangle4.Width = (control.EndTest - control.StartDatumTest).Value.Days * 22;
        //control.Grid.Children.Add(rectangle4);

        //Rectangle rectangle5 = new Rectangle();
        //rectangle5.Height = 100;
        //rectangle5.Fill = Brushes.Red;
        //rectangle5.HorizontalAlignment = HorizontalAlignment.Left;
        //days = (control.StartDatumBetrieb - control.MinDatum).Value.Days - 1;
        //rectangle5.Margin = new Thickness(1 + days * 22, 0, 0, 0);
        //rectangle5.Width = (control.EndBetrieb - control.StartDatumBetrieb).Value.Days * 22;
        //control.Grid.Children.Add(rectangle5);
    }
}