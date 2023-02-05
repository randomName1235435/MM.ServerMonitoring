using Microsoft.Extensions.DependencyInjection;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Model.Mapper;

public static class MapperServiceCollectionExtensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddTransient<IMapper<Monitor, Dto.Model.Crud.Monitor>, MonitorMapper>();
        services
            .AddTransient<IMapper<MonitorActionExecution, Dto.Model.Crud.MonitorActionExecution>,
                MonitorActionExecutionMapper>();
        services.AddTransient<IMapper<Action, Dto.Model.Crud.Action>, ActionMapper>();
        services.AddTransient<IMapper<Parameter, Dto.Model.Crud.Parameter>, ParameterMapper>();
        services.AddTransient<IMapper<ParameterTyp, Dto.Model.Crud.ParameterTyp>, ParameterTypMapper>();
        services.AddTransient<IMapper<Target, Dto.Model.Crud.Target>, TargetMapper>();
        services.AddTransient<IMapper<TargetTyp, Dto.Model.Crud.TargetTyp>, TargetTypMapper>();
        services.AddTransient<IOneWayMapper<MonitorDto, Monitor>, MonitorDtoMapper>();
        services
            .AddTransient<IOneWayMapper<MonitorActionExecutionDto, MonitorActionExecution>,
                MonitorActionExecutionDtoMapper>();
        services.AddTransient<IOneWayMapper<DashboardDto, Dashboard>, DashboardDtoMapper>();

        return services;
    }
}