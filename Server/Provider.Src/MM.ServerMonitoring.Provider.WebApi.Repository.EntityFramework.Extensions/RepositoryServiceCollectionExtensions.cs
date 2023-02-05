using Microsoft.Extensions.DependencyInjection;
using MM.ServerMonitoring.Repository.EntityFramework;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Extensions;

public static class RepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services.AddTransient<IDataContext, ServerMonitoringDataContext>();

        return services;
    }

    public static IServiceCollection AddModelBootstrapper(this IServiceCollection services)
    {
        services.AddTransient<IModelBootstrapper, DefaultModelBootstrapper>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IDataContext, ServerMonitoringDataContext>();
        services.AddTransient<IDataContextAsync, ServerMonitoringDataContext>();

        services.AddTransient<IRepository<Parameter>, RepositoryBase<Parameter>>();
        services.AddTransient<IRepository<Action>, RepositoryBase<Action>>();
        services.AddTransient<IRepository<Monitor>, RepositoryBase<Monitor>>();
        services.AddTransient<IRepository<MonitorActionExecution>, RepositoryBase<MonitorActionExecution>>();
        services.AddTransient<IRepository<ParameterTyp>, RepositoryBase<ParameterTyp>>();
        services.AddTransient<IRepository<Target>, RepositoryBase<Target>>();
        services.AddTransient<IRepository<TargetTyp>, RepositoryBase<TargetTyp>>();

        services.AddTransient<IRepositoryAsync<Parameter>, RepositoryBase<Parameter>>();
        services.AddTransient<IRepositoryAsync<Action>, RepositoryBase<Action>>();
        services.AddTransient<IRepositoryAsync<Monitor>, RepositoryBase<Monitor>>();
        services.AddTransient<IRepositoryAsync<MonitorActionExecution>, RepositoryBase<MonitorActionExecution>>();
        services.AddTransient<IRepositoryAsync<ParameterTyp>, RepositoryBase<ParameterTyp>>();
        services.AddTransient<IRepositoryAsync<Target>, RepositoryBase<Target>>();
        services.AddTransient<IRepositoryAsync<TargetTyp>, RepositoryBase<TargetTyp>>();

        return services;
    }
}