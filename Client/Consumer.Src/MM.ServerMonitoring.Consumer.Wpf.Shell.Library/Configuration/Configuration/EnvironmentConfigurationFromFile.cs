using System.IO;
using Config.Net;
using MM.ServerMonitoring.Consumer.Wpf.Interface;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Configuration.Configuration;

public class EnvironmentConfigurationFromFile : IEnvironmentConfiguration
{
    private const string configFileName = "config.json";

    private readonly Model.Configuration config;

    public EnvironmentConfigurationFromFile()
    {
        var startupPath = Environment.ProcessPath;
        if (startupPath is null) startupPath = string.Empty;

        var settings = new ConfigurationBuilder<IFromFileConfigWrapper>()
            .UseJsonFile(Path.Combine(startupPath, configFileName))
            .Build();

        this.config = new Model.Configuration
        {
            BaseApiAdress = new Uri(settings.BaseApiAdress)
        };
    }

    public Model.Configuration Get()
    {
        return this.config;
    }
}