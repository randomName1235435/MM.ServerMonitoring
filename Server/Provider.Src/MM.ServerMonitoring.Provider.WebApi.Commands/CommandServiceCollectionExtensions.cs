using Microsoft.Extensions.DependencyInjection;
using MM.ServerMonitoring.Provider.WebApi.Commands.Crud;
using MM.ServerMonitoring.Provider.WebApi.Commands.Dto;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;
using MM.ServerMonitoring.Repository.EntityFramework.Service;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Commands;

public static class CommandServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddDefault<MonitorActionExecution>();
        services.AddDefault<Monitor>();
        services.AddDefault<Action>();
        services.AddDefault<Parameter>();
        services.AddDefault<ParameterTyp>();
        services.AddDefault<TargetTyp>();
        services.AddDefault<Target>();

        services.AddTransient<IDashboardService, DashboardService>();
        services.AddTransient<ICrudServiceAsync<Monitor>, MonitorCrudService>();
        services.AddTransient<ICrudServiceAsync<MonitorActionExecution>, MonitorActionExecutionCrudService>();
        services.AddTransient<ICrudServiceAsync<Action>, ActionCrudService>();
        services.AddTransient<ICrudServiceAsync<Parameter>, ParameterCrudService>();
        services.AddTransient<ICrudServiceAsync<ParameterTyp>, ParameterTypCrudService>();
        services.AddTransient<ICrudServiceAsync<TargetTyp>, TargetTypCrudService>();
        services.AddTransient<ICrudServiceAsync<Target>, TargetCrudService>();

        services
            .AddTransient<IReadWithIncludesCommand<IEnumerable<MonitorActionExecution>>,
                ReadMonitorActionExecutionWithIncludesCommand>();
        services
            .AddTransient<IReadByIdWithIncludesCommand<Guid, MonitorActionExecution>,
                ReadMonitorActionExecutionByIdWithIncludesCommand>();

        services.AddTransient<IReadWithIncludesCommand<IEnumerable<Monitor>>, ReadMonitorWithIncludesCommand>();
        services.AddTransient<IReadByIdWithIncludesCommand<Guid, Monitor>, ReadMonitorByIdWithIncludesCommand>();

        services.AddTransient<IDashboardService, DashboardService>();
        services.AddTransient<IReadCommand<Dashboard>, ReadDashboardCommand>();

        return services;
    }

    public static IServiceCollection AddDefault<TEntity>(this IServiceCollection services) where TEntity : class, IHasId
    {
        services.AddTransient<IReadCommand<IEnumerable<TEntity>>, ReadCommand<TEntity, ICrudServiceAsync<TEntity>>>();
        services.AddTransient<IReadByIdCommand<Guid, TEntity>, ReadByIdCommand<TEntity, ICrudServiceAsync<TEntity>>>();
        services.AddTransient<IInsertCommand<TEntity, Guid>, InsertCommand<TEntity, ICrudServiceAsync<TEntity>>>();
        services
            .AddTransient<IDeleteByIdCommand<Guid, TEntity>, DeleteByIdCommand<TEntity, ICrudServiceAsync<TEntity>>>();
        services.AddTransient<IUpdateCommand<TEntity>, UpdateCommand<TEntity, ICrudServiceAsync<TEntity>>>();
        services.AddTransient<ICommandFactory<TEntity>, DefaultCommandFactory<TEntity>>();

        return services;
    }
}