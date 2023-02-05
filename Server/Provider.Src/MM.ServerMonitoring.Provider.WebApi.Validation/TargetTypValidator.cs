using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class TargetTypValidator : IInsertValidator<TargetTyp>, IUpdateValidator<TargetTyp>, IDeleteValidator<TargetTyp>
{
    private readonly ICrudServiceAsync<TargetTyp> crudService;
    private readonly ICrudServiceAsync<Target> targetCrudService;

    public TargetTypValidator(
        ICrudServiceAsync<TargetTyp> crudService,
        ICrudServiceAsync<Target> targetCrudService)

    {
        this.crudService = crudService;
        this.targetCrudService = targetCrudService;
    }

    ValidationResult IDeleteValidator<TargetTyp>.Validate(TargetTyp item)
    {
        var result = new ValidationResult();
        DefaultValidations.ExistingId(item, result, this.crudService);
        DefaultValidations.NotExistingDepedencies(item, result, this.targetCrudService);
        return result;
    }

    ValidationResult IInsertValidator<TargetTyp>.Validate(TargetTyp item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.NotExistingId(item, result, this.crudService);
        return result;
    }

    ValidationResult IUpdateValidator<TargetTyp>.Validate(TargetTyp item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.ExistingId(item, result, this.crudService);
        return result;
    }
}