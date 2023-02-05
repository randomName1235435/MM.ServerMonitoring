using MM.ServerMonitoring.ActionExecutor.Actions.PingAction;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public class Monitor : IMonitor
{
    private readonly IAction action;
    private readonly Guid monitorId;
    private readonly IMinimalRepository<ActionExecutionResult> repository;
    private ActionConfiguration configuration;

    public Monitor(ActionConfiguration configuration, IAction action,
        IMinimalRepository<ActionExecutionResult> repository, Guid monitorId)
    {
        _ = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _ = action ?? throw new ArgumentNullException(nameof(action));
        _ = repository ?? throw new ArgumentNullException(nameof(repository));

        this.configuration = configuration;
        this.action = action;
        this.repository = repository;
        this.monitorId = monitorId;
    }

    public async Task<ActionExecutionResult> RunAsync(CancellationToken cancellationToken)
    {
        var result = await this.action.ExecuteAsync(cancellationToken);
        result.AddMonitorId(this.monitorId);

        var jsonString = JsonSerializer.Serialize(result);
        Console.WriteLine(JToken.Parse(jsonString).ToString(Formatting.Indented));

        await this.repository.InsertAsync(result, cancellationToken);
        return result;
    }
}