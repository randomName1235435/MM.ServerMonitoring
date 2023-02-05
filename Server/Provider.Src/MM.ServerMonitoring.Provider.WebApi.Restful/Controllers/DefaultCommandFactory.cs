using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers;

public class DefaultCommandFactory<TEntity> : ICommandFactory<TEntity>
{
    public DefaultCommandFactory(
        IReadCommand<IEnumerable<TEntity>> readCommand,
        IReadByIdCommand<Guid, TEntity> readByIdCommand,
        IUpdateCommand<TEntity> updateCommand,
        IDeleteByIdCommand<Guid, TEntity> deleteByIdCommand,
        IInsertCommand<TEntity, Guid> insertCommand)
    {
        _ = readCommand ?? throw new ArgumentNullException(nameof(readCommand));
        _ = readByIdCommand ?? throw new ArgumentNullException(nameof(readByIdCommand));
        _ = updateCommand ?? throw new ArgumentNullException(nameof(updateCommand));
        _ = deleteByIdCommand ?? throw new ArgumentNullException(nameof(deleteByIdCommand));
        _ = insertCommand ?? throw new ArgumentNullException(nameof(insertCommand));

        ReadCommand = readCommand;
        ReadByIdCommand = readByIdCommand;
        UpdateCommand = updateCommand;
        DeleteByIdCommand = deleteByIdCommand;
        InsertCommand = insertCommand;
    }

    public IReadCommand<IEnumerable<TEntity>> ReadCommand { get; }
    public IReadByIdCommand<Guid, TEntity> ReadByIdCommand { get; }
    public IUpdateCommand<TEntity> UpdateCommand { get; }
    public IDeleteByIdCommand<Guid, TEntity> DeleteByIdCommand { get; }
    public IInsertCommand<TEntity, Guid> InsertCommand { get; }
}