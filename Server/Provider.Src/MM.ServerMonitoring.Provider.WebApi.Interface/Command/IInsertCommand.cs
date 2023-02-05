namespace MM.ServerMonitoring.Provider.WebApi.Interface.Command;

public interface IInsertCommand<in TParam, TResult>
{
    Task<TResult> ExecuteAsync(TParam param, CancellationToken cancellationToken);
    TResult Execute(TParam param);
}