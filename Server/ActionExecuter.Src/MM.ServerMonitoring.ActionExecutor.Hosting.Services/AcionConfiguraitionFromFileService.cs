using System.Text.Json;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public class AcionConfiguraitionFromFileService : IAcionConfigurationService<PathParameter>
{
    public async Task<ActionConfiguration[]> CreateConfigurationAsync(PathParameter workerConfigurationParameter)
    {
        return await this.CreateConfigurationFromFileAsync(workerConfigurationParameter);
    }

    public async Task<ActionConfiguration[]> CreateConfigurationFromFileAsync(
        PathParameter workerConfigurationParameter)
    {
        if (workerConfigurationParameter is PathParameter pathParameter)
        {
            var jsonText = File.OpenRead(pathParameter.Path);
            var result = await JsonSerializer
                .DeserializeAsync<ActionConfiguration[]>(jsonText);
            return result;
        }

        throw new NotImplementedException("no more yet :|");
    }
}

//public class WorkerConfigurationServiceFromEf : IWorkerConfigurationService
//{
//    public async Task<IEnumerable<ActionConfiguration>> GetAll()
//    {
//        return await Array.Empty<ActionConfiguration>();
//    }
//}