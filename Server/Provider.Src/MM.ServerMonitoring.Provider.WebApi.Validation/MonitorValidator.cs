using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class MonitorValidator : IInsertValidator<Monitor>, IUpdateValidator<Monitor>, IDeleteValidator<Monitor>
{
    private readonly ICrudServiceAsync<Action> actionCrudService;
    private readonly ICrudServiceAsync<Monitor> crudService;
    private readonly ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService;
    private readonly ICrudServiceAsync<Parameter> parameterCrudService;

    private readonly ICrudServiceAsync<Target> targetCrudService;

    //todo null argument validation on all ctor on validation
    public MonitorValidator(
        ICrudServiceAsync<Monitor> crudService,
        ICrudServiceAsync<Action> actionCrudService,
        ICrudServiceAsync<Target> targetCrudService,
        ICrudServiceAsync<Parameter> parameterCrudService,
        ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService)
    {
        this.crudService = crudService;
        this.actionCrudService = actionCrudService;
        this.targetCrudService = targetCrudService;
        this.parameterCrudService = parameterCrudService;
        this.monitorActionExecutionCrudService = monitorActionExecutionCrudService;
    }

    ValidationResult IDeleteValidator<Monitor>.Validate(Monitor item)
    {
        var result = new ValidationResult();
        DefaultValidations.ExistingId(item, result, this.crudService);
        DefaultValidations.NotExistingDepedencies(item, result, this.monitorActionExecutionCrudService);
        return result;
    }

    ValidationResult IInsertValidator<Monitor>.Validate(Monitor item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.ActionId(item, result, this.actionCrudService);
        DefaultValidations.TargetId(item, result, this.targetCrudService);
        DefaultValidations.ParameterId(item, result, this.parameterCrudService);
        DefaultValidations.NotExistingId(item, result, this.crudService);
        return result;
    }

    ValidationResult IUpdateValidator<Monitor>.Validate(Monitor item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.ActionId(item, result, this.actionCrudService);
        DefaultValidations.TargetId(item, result, this.targetCrudService);
        DefaultValidations.ExistingId(item, result, this.crudService);
        return result;
    }
}