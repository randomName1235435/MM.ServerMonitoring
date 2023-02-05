namespace MM.ServerMonitoring.Provider.WebApi.Interface.Command;

public interface IReadByIdWithIncludesCommand<in TParameter, TResult>
{
    Task<TResult> ExecuteAsync(TParameter item, CancellationToken cancellationToken);
    TResult Execute(TParameter item);
}