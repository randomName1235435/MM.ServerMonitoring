using Microsoft.Extensions.DependencyInjection;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public static class ValidatorServiceCollectionExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddTransient<IInsertValidator<Monitor>, MonitorValidator>();
        services.AddTransient<IUpdateValidator<Monitor>, MonitorValidator>();
        services.AddTransient<IDeleteValidator<Monitor>, MonitorValidator>();

        services.AddTransient<IInsertValidator<MonitorActionExecution>, MonitorActionExecutionValidator>();
        services.AddTransient<IUpdateValidator<MonitorActionExecution>, MonitorActionExecutionValidator>();
        services.AddTransient<IDeleteValidator<MonitorActionExecution>, MonitorActionExecutionValidator>();

        services.AddTransient<IInsertValidator<Parameter>, ParameterValidator>();
        services.AddTransient<IUpdateValidator<Parameter>, ParameterValidator>();
        services.AddTransient<IDeleteValidator<Parameter>, ParameterValidator>();

        services.AddTransient<IInsertValidator<ParameterTyp>, ParameterTypValidator>();
        services.AddTransient<IUpdateValidator<ParameterTyp>, ParameterTypValidator>();
        services.AddTransient<IDeleteValidator<ParameterTyp>, ParameterTypValidator>();

        services.AddTransient<IInsertValidator<Target>, TargetValidator>();
        services.AddTransient<IUpdateValidator<Target>, TargetValidator>();
        services.AddTransient<IDeleteValidator<Target>, TargetValidator>();

        services.AddTransient<IInsertValidator<TargetTyp>, TargetTypValidator>();
        services.AddTransient<IUpdateValidator<TargetTyp>, TargetTypValidator>();
        services.AddTransient<IDeleteValidator<TargetTyp>, TargetTypValidator>();

        services.AddTransient<IInsertValidator<Action>, ActionValidator>();
        services.AddTransient<IUpdateValidator<Action>, ActionValidator>();
        services.AddTransient<IDeleteValidator<Action>, ActionValidator>();

        return services;
    }
}