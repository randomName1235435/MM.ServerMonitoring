using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class ParameterValidator : IInsertValidator<Parameter>, IUpdateValidator<Parameter>, IDeleteValidator<Parameter>
{
    private readonly ICrudServiceAsync<Action> actionCrudService;
    private readonly ICrudServiceAsync<Parameter> crudService;
    private readonly ICrudServiceAsync<Monitor> monitorCrudService;
    private readonly ICrudServiceAsync<ParameterTyp> parameterTypCrudService;
    private readonly ICrudServiceAsync<Target> targetCrudService;

    public ParameterValidator(
        ICrudServiceAsync<Parameter> crudService,
        ICrudServiceAsync<ParameterTyp> parameterTypCrudService,
        ICrudServiceAsync<Action> actionCrudService,
        ICrudServiceAsync<Target> targetCrudService,
        ICrudServiceAsync<Monitor> monitorCrudService)
    {
        this.crudService = crudService;
        this.parameterTypCrudService = parameterTypCrudService;
        this.actionCrudService = actionCrudService;
        this.targetCrudService = targetCrudService;
        this.monitorCrudService = monitorCrudService;
    }

    ValidationResult IDeleteValidator<Parameter>.Validate(Parameter item)
    {
        var result = new ValidationResult();
        DefaultValidations.ExistingId(item, result, this.crudService);
        DefaultValidations.NotExistingDepedencies(item, result, this.monitorCrudService);
        return result;
    }

    ValidationResult IInsertValidator<Parameter>.Validate(Parameter item)
    {
        var result = new ValidationResult();
        DefaultValidations.ParameterTypId(item, result, this.parameterTypCrudService);
        DefaultValidations.NotExistingId(item, result, this.crudService);
        return result;
    }

    ValidationResult IUpdateValidator<Parameter>.Validate(Parameter item)
    {
        var result = new ValidationResult();
        DefaultValidations.ParameterTypId(item, result, this.parameterTypCrudService);
        DefaultValidations.ExistingId(item, result, this.crudService);
        return result;
    }
}