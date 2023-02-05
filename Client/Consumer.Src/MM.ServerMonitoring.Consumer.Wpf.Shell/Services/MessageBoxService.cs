using System.Windows;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Services;

public class MessageBoxService : IMessageBoxService
{
    public void Show(string message)
    {
        MessageBox.Show(message);
    }

    public MessageBoxResult Show(string message, MessageBoxButton buttons)
    {
        return MessageBox.Show(message, "there is something..", buttons);
    }
}