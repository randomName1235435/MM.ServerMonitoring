using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class TargetValidator : IInsertValidator<Target>, IUpdateValidator<Target>, IDeleteValidator<Target>
{
    private readonly ICrudServiceAsync<Target> crudService;
    private readonly ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService;
    private readonly ICrudServiceAsync<Monitor> monitorCrudService;
    private readonly ICrudServiceAsync<TargetTyp> targetTypCrudService;

    public TargetValidator(
        ICrudServiceAsync<Target> crudService,
        ICrudServiceAsync<TargetTyp> targetTypCrudService,
        ICrudServiceAsync<Monitor> monitorCrudService,
        ICrudServiceAsync<MonitorActionExecution> monitorActionExecutionCrudService
    )

    {
        this.crudService = crudService;
        this.targetTypCrudService = targetTypCrudService;
        this.monitorCrudService = monitorCrudService;
        this.monitorActionExecutionCrudService = monitorActionExecutionCrudService;
    }

    ValidationResult IDeleteValidator<Target>.Validate(Target item)
    {
        var result = new ValidationResult();
        DefaultValidations.ExistingId(item, result, this.crudService);
        DefaultValidations.NotExistingDepedencies(item, result, this.monitorCrudService,
            this.monitorActionExecutionCrudService);
        return result;
    }

    ValidationResult IInsertValidator<Target>.Validate(Target item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.TargetTypId(item, result, this.targetTypCrudService);
        DefaultValidations.NotExistingId(item, result, this.crudService);
        return result;
    }

    ValidationResult IUpdateValidator<Target>.Validate(Target item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.TargetTypId(item, result, this.targetTypCrudService);
        DefaultValidations.ExistingId(item, result, this.crudService);
        return result;
    }
}