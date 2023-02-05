namespace MM.ServerMonitoring.Consumer.Wpf.Interface;

public interface IReadableLogger
{
    public IReadOnlyCollection<string> Messages { get; }
}