using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Dto;

public class ReadDashboardCommand : IReadCommand<Dashboard>
{
    protected readonly IDashboardService service;

    public ReadDashboardCommand(IDashboardService service)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));

        this.service = service;
    }

    public virtual async Task<Dashboard> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await this.service.ReadAsync(cancellationToken);
    }

    public virtual Dashboard Execute()
    {
        return this.service.Read();
    }
}