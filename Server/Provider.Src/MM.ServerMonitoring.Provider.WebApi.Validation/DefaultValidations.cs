using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public static class DefaultValidations
{
    public static void Name<TEntity>(TEntity item, ValidationResult result)
        where TEntity : IHasName
    {
        StringValidation.RequiredFieldMaxLength(item.Name, 100, nameof(item.Name))
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void Description<TEntity>(TEntity item, ValidationResult result)
        where TEntity : IHasDescription
    {
        StringValidation.RequiredFieldMaxLength(item.Description, 1000, nameof(item.Description))
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void ActionId<TEntity>(TEntity item, ValidationResult result,
        ICrudServiceAsync<Action> crudService)
        where TEntity : IHasActionId
    {
        DependencyValidation<Action>
            .NotEmptyAndFound(item.ActionId, nameof(item.ActionId), crudService)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void TargetTypId<TEntity>(TEntity item, ValidationResult result,
        ICrudServiceAsync<TargetTyp> crudService)
        where TEntity : IHasTargetTypId
    {
        {
            DependencyValidation<TargetTyp>.NotEmptyAndFound(item.TargetTypId, nameof(item.TargetTypId), crudService)
                .IfSome(ValidationResult => result.AddMessage(ValidationResult));
        }
        ;
    }

    public static void ParameterTypId<TEntity>(TEntity item, ValidationResult result,
        ICrudServiceAsync<ParameterTyp> crudService)
        where TEntity : IHasParameterTypId
    {
        DependencyValidation<ParameterTyp>
            .NotEmptyAndFound(item.ParameterTypId, nameof(item.ParameterTypId), crudService)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void TargetId<TEntity>(TEntity item, ValidationResult result, ICrudServiceAsync<Target> crudService)
        where TEntity : IHasTargetId
    {
        DependencyValidation<Target>.NotEmptyAndFound(item.TargetId, nameof(item.TargetId), crudService)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void ParameterId<TEntity>(TEntity item, ValidationResult result,
        ICrudServiceAsync<Parameter> crudService)
        where TEntity : IHasParameterId
    {
        DependencyValidation<Parameter>.NotEmptyAndFound(item.ParameterId, nameof(item.ParameterId), crudService)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void MonitorId<TEntity>(TEntity item, ValidationResult result,
        ICrudServiceAsync<Monitor> crudService)
        where TEntity : IHasMonitorId
    {
        DependencyValidation<Monitor>.NotEmptyAndFound(item.MonitorId, nameof(item.MonitorId), crudService)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void NotExistingId<TEntity>(TEntity item, ValidationResult result,
        ICrudServiceAsync<TEntity> crudService)
        where TEntity : class, IHasId
    {
        DependencyValidation<TEntity>.NotEmptyAndNotFound(item.Id, nameof(item.Id), crudService)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void ExistingId<TEntity>(TEntity item, ValidationResult result,
        ICrudServiceAsync<TEntity> crudService)
        where TEntity : class, IHasId
    {
        DependencyValidation<TEntity>.NotEmptyAndFound(item.Id, nameof(item.Id), crudService)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void NotExistingDepedencies(Monitor item, ValidationResult result,
        ICrudServiceAsync<MonitorActionExecution> crudService)
    {
        DependencyValidation<Monitor>.MustNotFound(item.Id,
                nameof(item.Id),
                crudService,
                depdency => depdency.MonitorId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void NotExistingDepedencies(TargetTyp item, ValidationResult result,
        ICrudServiceAsync<Target> crudService)
    {
        DependencyValidation<Target>.MustNotFound(item.Id,
                nameof(item.Id),
                crudService,
                depdency => depdency.TargetTypId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void NotExistingDepedencies(Target item, ValidationResult result,
        ICrudServiceAsync<Monitor> actionCrudService,
        ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService)
    {
        DependencyValidation<Target>.MustNotFound(item.Id,
                nameof(item.Id),
                actionCrudService,
                depdency => depdency.TargetId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
        DependencyValidation<Target>.MustNotFound(item.Id,
                nameof(item.Id),
                monitorActionExecutionCrudService,
                depdency => depdency.TargetId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void NotExistingDepedencies(Action item, ValidationResult result,
        ICrudServiceAsync<Monitor> actionCrudService,
        ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService)
    {
        DependencyValidation<Target>.MustNotFound(item.Id,
                nameof(item.Id),
                actionCrudService,
                depdency => depdency.ActionId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
        DependencyValidation<Target>.MustNotFound(item.Id,
                nameof(item.Id),
                monitorActionExecutionCrudService,
                depdency => depdency.ActionId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void NotExistingDepedencies(ParameterTyp item, ValidationResult result,
        ICrudServiceAsync<Parameter> crudService)
    {
        DependencyValidation<Parameter>.MustNotFound(item.Id,
                nameof(item.Id),
                crudService,
                depdency => depdency.ParameterTypId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void NotExistingDepedencies(Parameter item, ValidationResult result,
        ICrudServiceAsync<Monitor> crudService)
    {
        DependencyValidation<Monitor>.MustNotFound(item.Id,
                nameof(item.Id),
                crudService,
                depdency => depdency.ParameterId == item.Id)
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }

    public static void StartFinish<TEntity>(TEntity item, ValidationResult result)
        where TEntity : class, IHasStartFinish
    {
        DateTimeValidation<MonitorActionExecution>
            .MustBeGreaterThan(item.Finish, nameof(item.Finish), item.Start, nameof(item.Start))
            .IfSome(ValidationResult => result.AddMessage(ValidationResult));
    }
}