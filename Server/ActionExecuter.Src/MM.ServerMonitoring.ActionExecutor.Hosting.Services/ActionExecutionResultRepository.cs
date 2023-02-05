using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public class ActionExecutionResultRepository : IMinimalRepository<ActionExecutionResult>
{
    private readonly IRepositoryAsync<MonitorActionExecution> actionExecutionResultrepository;
    private readonly IRepositoryAsync<Repository.EntityFramework.Model.Monitor> monitorRepository;

    public ActionExecutionResultRepository(
        IRepositoryAsync<MonitorActionExecution> actionExecutionResultrepository,
        IRepositoryAsync<Repository.EntityFramework.Model.Monitor> monitorRepository
    )
    {
        this.monitorRepository = monitorRepository;
        this.actionExecutionResultrepository = actionExecutionResultrepository;
    }

    public async Task InsertAsync(ActionExecutionResult input, CancellationToken cancellationToken)
    {
        var monitorActionExecution = new MonitorActionExecution
        {
            ActionId = input.ActionId,
            MonitorId = input.MonitorId,
            TargetId = this.monitorRepository.FindById(input.MonitorId).TargetId,
            Finish = DateTime.Now, //maybe somewhere else?
            Id = Guid.NewGuid(), //maybe somewhere else?
            Message = string.Join(Environment.NewLine, input.Messages),
            WasSuccess = input.Success,
            Start = input.Start
        };

        await this.actionExecutionResultrepository.InsertAsync(monitorActionExecution, cancellationToken);
    }
}