using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class DashboardService : IDashboardService
{
    private readonly IRepositoryAsync<Action> actionRepository;
    private readonly IRepositoryAsync<MonitorActionExecution> monitorActionExecutionRepository;
    private readonly IRepositoryAsync<Monitor> monitorRepository;

    public DashboardService(
        IRepositoryAsync<Monitor> monitorRepository,
        IRepositoryAsync<MonitorActionExecution> monitorActionExecutionRepository,
        IRepositoryAsync<Action> actionRepository
    )
    {
        _ = monitorRepository ?? throw new ArgumentNullException(nameof(monitorRepository));
        _ = monitorActionExecutionRepository ??
            throw new ArgumentNullException(nameof(monitorActionExecutionRepository));
        _ = actionRepository ?? throw new ArgumentNullException(nameof(actionRepository));

        this.monitorRepository = monitorRepository;
        this.monitorActionExecutionRepository = monitorActionExecutionRepository;
        this.actionRepository = actionRepository;
    }

    public Dashboard Read()
    {
        var result = new Dashboard();

        result.CountActions = this.actionRepository.Read(q => q.Count());
        result.CountFailed = this.monitorActionExecutionRepository.Read(q => q.Count(item => !item.WasSuccess));
        result.CountSuccess = this.monitorActionExecutionRepository.Read(q => q.Count(item => !item.WasSuccess));
        result.CountFailedLastHour = this.monitorActionExecutionRepository.Read(q =>
            q.Count(item => !item.WasSuccess && item.Start >= DateTime.Now.AddHours(-1)));
        result.CountMonitor = this.monitorRepository.Read(q => q.Count());
        result.CountResults = this.monitorActionExecutionRepository.Read(q => q.Count());

        return result;
    }

    public async Task<Dashboard> ReadAsync(CancellationToken cancellationToken)
    {
        var result = new Dashboard();

        result.CountActions = await this.actionRepository.CountAsync(q => q, cancellationToken);
        result.CountFailed =
            await this.monitorActionExecutionRepository.CountAsync(q => q.Where(item => !item.WasSuccess),
                cancellationToken);
        result.CountSuccess =
            await this.monitorActionExecutionRepository.CountAsync(q => q.Where(item => !item.WasSuccess),
                cancellationToken);
        result.CountFailedLastHour = await this.monitorActionExecutionRepository.CountAsync(
            q => q.Where(item => !item.WasSuccess && item.Start >= DateTime.Now.AddHours(-1)), cancellationToken);
        result.CountMonitor = await this.monitorRepository.CountAsync(q => q, cancellationToken);
        result.CountResults = await this.monitorActionExecutionRepository.CountAsync(q => q, cancellationToken);

        return result;
    }

    public async Task<Dashboard> ReadAsync()
    {
        return await this.ReadAsync(CancellationToken.None);
    }
}