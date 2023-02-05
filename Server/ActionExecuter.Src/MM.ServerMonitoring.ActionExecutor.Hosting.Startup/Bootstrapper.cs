using MM.ServerMonitoring.ActionExecutor.EntityFramework.Model.Mapper;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.IocContainer.LightInject;
using MM.ServerMonitoring.ActionExecutor.Model;
using MM.ServerMonitoring.ActionExecutor.Services;
using MM.ServerMonitoring.Repository.EntityFramework;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.ActionExecutor.Startup;

public class Bootstrapper
{
    public static IContainer Run()
    {
        var rootContainer = ContainerFactory.Create();

        AddServices(rootContainer);
        return rootContainer;
    }

    private static void AddServices(IContainer container)
    {
        container.Register<IAcionConfigurationService<PathParameter>, AcionConfiguraitionFromFileService>();
        container.Register<IMonitorFactory, MonitorFactory>();
        container.Register<IActionProvider, ActionProvider>();
        container.Register<IMonitorProvider, MonitorProvider>();
        container.Register<IMonitorFactory, MonitorFactory>();
        //container.Register<ILoggingProvider, LoggingProvider>();
        AddMonitorConfigurationFromEf(container);
        AddRepositoryFromEf(container);
        container.Register<IMapper<Monitor, MonitorConfiguration>, MonitorMapper>();
        AddEntityFramework(container);
    }

    private static void AddRepositoryFromEf(IContainer container)
    {
        container.Register<IMinimalRepository<ActionExecutionResult>, ActionExecutionResultRepository>();
        container.Register<IRepository<MonitorActionExecution>, RepositoryBase<MonitorActionExecution>>();
    }

    private static void AddMonitorConfigurationFromFile(IContainer container)
    {
        container.Register<IMonitorConfiguration, MonitorConfigurationFromFile>();
    }

    private static void AddMonitorConfigurationFromEf(IContainer container)
    {
        container.Register<IMonitorConfiguration, MonitorConfigurationFromEf>();
    }

    private static void AddEntityFramework(IContainer container)
    {
        container.Register<IDataContext, ServerMonitoringDataContext>();
        container.Register<IModelBootstrapper, DefaultModelBootstrapper>();
        container.Register<IRepository<Parameter>, RepositoryBase<Parameter>>();
        container.Register<IRepository<Action>, RepositoryBase<Action>>();
        container.Register<IRepository<Monitor>, RepositoryBase<Monitor>>();
        container.Register<IRepository<MonitorActionExecution>, RepositoryBase<MonitorActionExecution>>();
        container.Register<IRepository<ParameterTyp>, RepositoryBase<ParameterTyp>>();
        container.Register<IRepository<Target>, RepositoryBase<Target>>();
        container.Register<IRepository<TargetTyp>, RepositoryBase<TargetTyp>>();

        container.Register<IDataContextAsync, ServerMonitoringDataContext>();
        container.Register<IModelBootstrapper, DefaultModelBootstrapper>();
        container.Register<IRepositoryAsync<Parameter>, RepositoryBase<Parameter>>();
        container.Register<IRepositoryAsync<Action>, RepositoryBase<Action>>();
        container.Register<IRepositoryAsync<Monitor>, RepositoryBase<Monitor>>();
        container.Register<IRepositoryAsync<MonitorActionExecution>, RepositoryBase<MonitorActionExecution>>();
        container.Register<IRepositoryAsync<ParameterTyp>, RepositoryBase<ParameterTyp>>();
        container.Register<IRepositoryAsync<Target>, RepositoryBase<Target>>();
        container.Register<IRepositoryAsync<TargetTyp>, RepositoryBase<TargetTyp>>();
    }
}