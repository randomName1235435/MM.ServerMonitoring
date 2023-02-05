using MM.ServerMonitoring.Provider.WebApi.Interface.Command;

namespace MM.ServerMonitoring.Provider.WebApi.Interface;

public interface ICommandFactory<TEntity>
{
    IReadCommand<IEnumerable<TEntity>> ReadCommand { get; }
    IReadByIdCommand<Guid, TEntity> ReadByIdCommand { get; }
    IUpdateCommand<TEntity> UpdateCommand { get; }
    IDeleteByIdCommand<Guid, TEntity> DeleteByIdCommand { get; }
    IInsertCommand<TEntity, Guid> InsertCommand { get; }
}