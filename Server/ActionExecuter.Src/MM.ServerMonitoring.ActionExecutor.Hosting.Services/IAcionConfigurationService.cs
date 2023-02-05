using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public interface IAcionConfigurationService<TWorkerConfigurationParameter>
    where TWorkerConfigurationParameter : WorkerConfigurationParameter
{
    Task<ActionConfiguration[]> CreateConfigurationAsync(TWorkerConfigurationParameter workerConfigurationParameter);
}

//public class WorkerConfigurationServiceFromEf : IWorkerConfigurationService
//{
//    public async Task<IEnumerable<ActionConfiguration>> GetAll()
//    {
//        return await Array.Empty<ActionConfiguration>();
//    }
//}