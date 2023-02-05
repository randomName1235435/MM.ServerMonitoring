//namespace MM.ServerMonitoring.Provider.WebApi.Repository.FromJsonFiles
//{
//    using MM.ServerMonitoring.ActionExecutor.Model;

//        public class AcionConfiguraitionFromFileService : IAcionConfigurationService<PathParameter>
//        {
//            public async Task<ActionConfiguration[]> CreateConfigurationAsync(PathParameter workerConfigurationParameter)
//            {
//                return await CreateConfigurationFromFileAsync(workerConfigurationParameter);
//            }
//            public async Task<ActionConfiguration[]> CreateConfigurationFromFileAsync(PathParameter workerConfigurationParameter)
//            {
//                if (workerConfigurationParameter is PathParameter pathParameter)
//                {
//                    var jsonText = File.OpenRead(pathParameter.Path);
//                    var result = await System.Text.Json.JsonSerializer
//                                .DeserializeAsync<ActionConfiguration[]>(jsonText);
//                    return result;
//                }
//                throw new NotImplementedException("no more yet :|");
//            }
//        }
//    }
////SQLEXPRESS
////public class WorkerConfigurationServiceFromEf : IWorkerConfigurationService
////{
////    public async Task<IEnumerable<ActionConfiguration>> GetAll()
////    {
////        return await Array.Empty<ActionConfiguration>();
////    }
////}

