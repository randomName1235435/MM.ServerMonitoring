using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class MonitorActionExecutionValidator : IInsertValidator<MonitorActionExecution>,
    IUpdateValidator<MonitorActionExecution>, IDeleteValidator<MonitorActionExecution>
{
    private readonly ICrudServiceAsync<Action> actionCrudService;
    private readonly ICrudServiceAsync<MonitorActionExecution> crudService;
    private readonly ICrudServiceAsync<Monitor> monitorCrudService;
    private readonly ICrudServiceAsync<Target> targetCrudService;

    public MonitorActionExecutionValidator(
        ICrudServiceAsync<MonitorActionExecution> crudService,
        ICrudServiceAsync<Monitor> monitorCrudService,
        ICrudServiceAsync<Action> actionCrudService,
        ICrudServiceAsync<Target> targetCrudService)
    {
        this.crudService = crudService;
        this.monitorCrudService = monitorCrudService;
        this.actionCrudService = actionCrudService;
        this.targetCrudService = targetCrudService;
    }

    ValidationResult IDeleteValidator<MonitorActionExecution>.Validate(MonitorActionExecution item)
    {
        var result = new ValidationResult();
        return result;
    }

    ValidationResult IInsertValidator<MonitorActionExecution>.Validate(MonitorActionExecution item)
    {
        var result = new ValidationResult();
        DefaultValidations.StartFinish(item, result);
        DefaultValidations.MonitorId(item, result, this.monitorCrudService);
        DefaultValidations.ActionId(item, result, this.actionCrudService);
        DefaultValidations.TargetId(item, result, this.targetCrudService);
        DefaultValidations.NotExistingId(item, result, this.crudService);
        return result;
    }

    ValidationResult IUpdateValidator<MonitorActionExecution>.Validate(MonitorActionExecution item)
    {
        var result = new ValidationResult();
        DefaultValidations.StartFinish(item, result);
        DefaultValidations.MonitorId(item, result, this.monitorCrudService);
        DefaultValidations.ActionId(item, result, this.actionCrudService);
        DefaultValidations.TargetId(item, result, this.targetCrudService);
        DefaultValidations.ExistingId(item, result, this.crudService);
        return result;
    }
}