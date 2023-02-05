namespace MM.ServerMonitoring.Consumer.Wpf.Interface;

public interface IDispatcher
{
    void Invoke(Action action);
}