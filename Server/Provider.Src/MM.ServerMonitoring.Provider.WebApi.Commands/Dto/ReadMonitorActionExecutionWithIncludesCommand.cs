using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Dto;

public class ReadMonitorActionExecutionWithIncludesCommand :
    IReadWithIncludesCommand<IEnumerable<MonitorActionExecution>>

{
    protected readonly ICrudServiceAsync<MonitorActionExecution> service;

    public ReadMonitorActionExecutionWithIncludesCommand(ICrudServiceAsync<MonitorActionExecution> service)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));

        this.service = service;
    }

    public virtual async Task<IEnumerable<MonitorActionExecution>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await this.service.ReadWithIncludesAsync(cancellationToken);
    }

    public virtual IEnumerable<MonitorActionExecution> Execute()
    {
        return this.service.ReadWithIncludes();
    }
}