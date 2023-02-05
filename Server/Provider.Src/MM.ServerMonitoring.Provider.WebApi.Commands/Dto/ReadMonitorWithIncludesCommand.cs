using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Dto;

public class ReadMonitorWithIncludesCommand :
    IReadWithIncludesCommand<IEnumerable<Monitor>>

{
    protected readonly ICrudServiceAsync<Monitor> service;

    public ReadMonitorWithIncludesCommand(ICrudServiceAsync<Monitor> service)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));

        this.service = service;
    }

    public virtual async Task<IEnumerable<Monitor>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await this.service.ReadWithIncludesAsync(cancellationToken);
    }

    public virtual IEnumerable<Monitor> Execute()
    {
        return this.service.ReadWithIncludes();
    }
}