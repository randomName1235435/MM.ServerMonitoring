using MM.ServerMonitoring.ActionExecutor.Interface;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public class MonitorProvider : IMonitorProvider
{
    private readonly IActionProvider actionProvider;
    private readonly IMonitorConfiguration monitorConfiguration;
    private readonly IMonitorFactory monitorFactory;

    public MonitorProvider(IMonitorConfiguration monitorConfiguration,
        IActionProvider actionProvider, IMonitorFactory monitorFactory)
    {
        _ = monitorConfiguration ?? throw new ArgumentNullException(nameof(monitorConfiguration));
        _ = actionProvider ?? throw new ArgumentNullException(nameof(actionProvider));
        _ = monitorFactory ?? throw new ArgumentNullException(nameof(monitorFactory));

        this.monitorConfiguration = monitorConfiguration;
        this.actionProvider = actionProvider;
        this.monitorFactory = monitorFactory;
    }

    public async Task<IEnumerable<IMonitor>> ProvideAllAsync(CancellationToken cancellationToken)
    {
        var configurationCollection = await this.monitorConfiguration.GetAsync(cancellationToken);
        var monitorCollection = configurationCollection
            .Select(configuration => this.monitorFactory.Create(
                this.actionProvider.Provide(configuration.ActionConfiguration),
                configuration.ActionConfiguration,
                configuration.MonitorId)
            );

        return monitorCollection;
    }
}