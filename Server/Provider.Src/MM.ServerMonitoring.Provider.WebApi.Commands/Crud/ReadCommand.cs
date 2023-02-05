using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Crud;

public class ReadCommand<TEntity, TService> :
    IReadCommand<IEnumerable<TEntity>>
    where TEntity : class, IHasId
    where TService : ICrudServiceAsync<TEntity>
{
    protected readonly TService service;

    public ReadCommand(TService service)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));

        this.service = service;
    }

    public virtual async Task<IEnumerable<TEntity>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await this.service.ReadAsync(cancellationToken);
    }

    public virtual IEnumerable<TEntity> Execute()
    {
        return this.service.Read();
    }
}