using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IMinimalRepository<T>
    where T : class
{
    public Task InsertAsync(ActionExecutionResult input, CancellationToken cancellationToken);
}