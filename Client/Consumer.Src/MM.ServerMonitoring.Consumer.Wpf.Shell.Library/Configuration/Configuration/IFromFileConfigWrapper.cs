using Config.Net;
using MM.ServerMonitoring.Consumer.Wpf.Model;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Configuration.Configuration;

public interface IFromFileConfigWrapper
{
    [Option(DefaultValue = @"http://localhost:19328/api")]
    string BaseApiAdress { get; }

    [Option(DefaultValue = MainWindowStartupLocation.Left)]
    MainWindowStartupLocation MainWindowStartupLocation { get; }
}