namespace MM.ServerMonitoring.Provider.WebApi.Interface.Command;

public interface IReadWithIncludesCommand<TResult>
{
    Task<TResult> ExecuteAsync(CancellationToken cancellationToken);
    TResult Execute();
}