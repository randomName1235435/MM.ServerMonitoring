using MM.ServerMonitoring.ActionExecutor.Interface;

namespace MM.ServerMonitoring.ActionExecuter.Hosting.BackgroundService.Worker;

//todo internal logging
public class Worker : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMonitor monitor;

    public Worker(ILogger<Worker> logger, IMonitor monitor)
    {
        _ = logger ?? throw new ArgumentNullException(nameof(logger));
        _ = monitor ?? throw new ArgumentNullException(nameof(monitor));

        this._logger = logger;
        this.monitor = monitor;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        this._logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await this.monitor.RunAsync(stoppingToken);
            }
            catch (Exception e)
            {
                this._logger.LogInformation(e.Message, DateTimeOffset.Now);
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}