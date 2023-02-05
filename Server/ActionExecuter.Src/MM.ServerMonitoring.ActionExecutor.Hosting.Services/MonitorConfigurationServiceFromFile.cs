//using MM.ServerMonitoring.ActionExecutor.Interface;
//using MM.ServerMonitoring.ActionExecutor.Model;
//using MM.ServerMonitoring.ActionExecutor.Infrastructure;

//namespace MM.ServerMonitoring.ActionExecutor.Services
//{
//    public class MonitorConfigurationServiceFromFile : IMonitorConfigurationService
//    {
//        private readonly IMonitorConfiguration monitorConfiguration;
//        private readonly IAcionConfigurationService<PathParameter> acionConfiguraitionService;

//        public MonitorConfigurationServiceFromFile(IMonitorConfiguration environmentConfiguration, IAcionConfigurationService<PathParameter> acionConfiguraitionService)
//        {
//            _ = environmentConfiguration ?? throw new ArgumentNullException(nameof(environmentConfiguration));
//            _ = acionConfiguraitionService ?? throw new ArgumentNullException(nameof(acionConfiguraitionService));

//            this.monitorConfiguration = environmentConfiguration;
//            this.acionConfiguraitionService = acionConfiguraitionService;
//        }

//        public async Task<IEnumerable<ActionConfiguration>> GetAllAsync()
//        {
//            var workerConfigurationParameterCollection = await monitorConfiguration
//                 .GetAsync();

//            var actionConfigurationCollection = await
//                workerConfigurationParameterCollection
//                .OfType<PathParameter>()
//                .SelectAsync(async workerConfigurationParameter =>
//                await acionConfiguraitionService.CreateConfigurationAsync(workerConfigurationParameter));
//            return actionConfigurationCollection.SelectMany(item => item);
//        }
//    }
//}

////public class WorkerConfigurationServiceFromEf : IWorkerConfigurationService
////{
////    public async Task<IEnumerable<ActionConfiguration>> GetAll()
////    {
////        return await Array.Empty<ActionConfiguration>();
////    }
////}

