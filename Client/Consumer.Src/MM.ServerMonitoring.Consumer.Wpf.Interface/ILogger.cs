namespace MM.ServerMonitoring.Consumer.Wpf.Interface;

public interface ILogger
{
    void Exception(Exception e);

    void Info(string message);
}