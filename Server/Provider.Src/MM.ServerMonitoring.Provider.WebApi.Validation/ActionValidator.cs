using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class ActionValidator : IInsertValidator<Action>, IUpdateValidator<Action>, IDeleteValidator<Action>
{
    private readonly ICrudServiceAsync<Action> crudService;
    private readonly ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService;
    private readonly ICrudServiceAsync<Monitor> monitorCrudService;

    public ActionValidator(
        ICrudServiceAsync<Action> crudService,
        ICrudServiceAsync<Monitor> monitorCrudService,
        ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService)
    {
        this.crudService = crudService;
        this.monitorCrudService = monitorCrudService;
        this.monitorActionExecutionCrudService = monitorActionExecutionCrudService;
    }

    ValidationResult IDeleteValidator<Action>.Validate(Action item)
    {
        var result = new ValidationResult();
        DefaultValidations.ExistingId(item, result, this.crudService);
        DefaultValidations.NotExistingDepedencies(item, result, this.monitorCrudService,
            this.monitorActionExecutionCrudService);
        return result;
    }

    ValidationResult IInsertValidator<Action>.Validate(Action item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.NotExistingId(item, result, this.crudService);
        return result;
    }

    ValidationResult IUpdateValidator<Action>.Validate(Action item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.ExistingId(item, result, this.crudService);
        return result;
    }
}