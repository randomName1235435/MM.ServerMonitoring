namespace MM.ServerMonitoring.Provider.WebApi.Interface.Command;

public interface IUpdateCommand<in TParameter>
{
    Task<Guid> ExecuteAsync(TParameter param, CancellationToken cancellationToken);
    void Execute(TParameter param);
}