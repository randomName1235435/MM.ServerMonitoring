using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Model;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Configuration.Configuration;

public class EnvironmentConfigurationFromHardCoded : IEnvironmentConfiguration
{
    private readonly Model.Configuration config;

    public EnvironmentConfigurationFromHardCoded()
    {
        this.config = new Model.Configuration
        {
            BaseApiAdress = new Uri(@"http://localhost:19328/api"),
            MainWindowStartupLocation = MainWindowStartupLocation.Left
        };
    }

    public Model.Configuration Get()
    {
        return this.config;
    }
}
//todo validationrules ordentlich einbauen in lib und config fuer json bauen