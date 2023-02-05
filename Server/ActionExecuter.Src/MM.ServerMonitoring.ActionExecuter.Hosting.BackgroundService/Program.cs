using MM.ServerMonitoring.ActionExecuter.Hosting.BackgroundService.Worker;
using MM.ServerMonitoring.ActionExecutor.Infrastructure;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Startup;

var container = Bootstrapper.Run();
var monitorProvider = container.Resolve<IMonitorProvider>();

IEnumerable<IMonitor> monitorCollection = null;

//var defaultTimeoutInMilliseconds = 3000;
//using (var cancellationTokenSource = new CancellationTokenSource())
//{
// try
//   {
//      cancellationTokenSource.CancelAfter(defaultTimeoutInMilliseconds);
//      cancellationTokenSource.Token.ThrowIfCancellationRequested();
monitorCollection = await monitorProvider.ProvideAllAsync(CancellationToken.None);
// }
//    catch (TaskCanceledException e)
//    {
//        Console.WriteLine("could establish server connection in timeout timespan");
//        return;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e);
//        return;
//    }
//}


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        monitorCollection.ForEach(item =>
            services.AddHostedService(serviceProvider =>
                new Worker(serviceProvider.GetService<ILogger<Worker>>(), item)));
    }).Build();

await host.RunAsync();