using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Dto;

public class ReadMonitorByIdWithIncludesCommand :
    IReadByIdWithIncludesCommand<Guid, Monitor>

{
    protected readonly ICrudServiceAsync<Monitor> service;

    public ReadMonitorByIdWithIncludesCommand(ICrudServiceAsync<Monitor> service)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));

        this.service = service;
    }

    public virtual async Task<Monitor> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty) throw new ArgumentException(nameof(id));

        var item = await this.service.FindByIdWithIncludesAsync(id, cancellationToken);
        if (item == null)
            throw new ItemNotFoundException();
        return item;
    }

    //todo reihenfolge bei 'withIncludes' vereinheitlichen
    public virtual Monitor Execute(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException(nameof(id));

        var item = this.service.FindByIdWithIncludes(id);
        if (item == null)
            throw new ItemNotFoundException();
        return item;
    }
}