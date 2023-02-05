using System.Windows;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;

public interface IMessageBoxService
{
    public void Show(string message);
    public MessageBoxResult Show(string message, MessageBoxButton buttons);
}