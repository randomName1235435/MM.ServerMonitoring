using System.Text.Json;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public class MonitorConfigurationFromFile : IMonitorConfiguration
{
    private const string workerFileName = @"ConfigFiles\config.environment.worker.json";
    private MonitorConfiguration[] cache;
    private Func<CancellationToken, Task> fillCache;

    public MonitorConfigurationFromFile()
    {
        this.fillCache = async cancellationToken => await this.FillCache(cancellationToken);
    }

    public async Task<IEnumerable<MonitorConfiguration>> GetAsync(CancellationToken cancellationToken)
    {
        await this.fillCache(cancellationToken);
        return this.cache;
    }

    private async Task FillCache(CancellationToken cancellationToken)
    {
        //todo add try, and add expetion logg it, catch later?
        var jsonText = File.OpenRead(workerFileName);
        this.cache = await JsonSerializer.DeserializeAsync<MonitorConfiguration[]>(jsonText, options: null,
            cancellationToken);
        this.fillCache = x => Task.CompletedTask;
    }
}