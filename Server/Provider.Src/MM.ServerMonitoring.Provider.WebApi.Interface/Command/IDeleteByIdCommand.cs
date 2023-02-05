namespace MM.ServerMonitoring.Provider.WebApi.Interface.Command;

public interface IDeleteByIdCommand<in TParam, TEntity>
{
    Task ExecuteAsync(TParam param, CancellationToken cancellationToken);
    void Execute(TParam param);
}