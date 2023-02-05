using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Crud;

public class ReadByIdCommand<TEntity, TService> :
    IReadByIdCommand<Guid, TEntity>
    where TEntity : class, IHasId
    where TService : ICrudServiceAsync<TEntity>
{
    protected readonly TService service;

    public ReadByIdCommand(TService service)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));

        this.service = service;
    }

    public virtual async Task<TEntity> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty) throw new ArgumentException(nameof(id));

        var item = await this.service.FindByIdAsync(id, cancellationToken);
        if (item == null)
            throw new ItemNotFoundException();
        return item;
    }

    public virtual TEntity Execute(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException(nameof(id));

        var item = this.service.FindById(id);
        if (item == null)
            throw new ItemNotFoundException();
        return item;
    }
}