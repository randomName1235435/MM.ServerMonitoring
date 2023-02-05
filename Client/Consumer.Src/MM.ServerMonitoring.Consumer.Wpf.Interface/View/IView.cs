namespace MM.ServerMonitoring.Consumer.Wpf.Interface.View;

public interface IView
{
    public object DataContext { get; set; }
    void NotifyOnLoaded(Action notify);
}