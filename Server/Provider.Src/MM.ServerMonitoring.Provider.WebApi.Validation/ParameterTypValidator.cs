using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class ParameterTypValidator : IInsertValidator<ParameterTyp>, IUpdateValidator<ParameterTyp>,
    IDeleteValidator<ParameterTyp>
{
    private readonly ICrudServiceAsync<ParameterTyp> crudService;
    private readonly ICrudServiceAsync<Parameter> parameterCrudService;

    public ParameterTypValidator(
        ICrudServiceAsync<ParameterTyp> crudService,
        ICrudServiceAsync<Parameter> parameterCrudService)

    {
        this.crudService = crudService;
        this.parameterCrudService = parameterCrudService;
    }

    ValidationResult IDeleteValidator<ParameterTyp>.Validate(ParameterTyp item)
    {
        var result = new ValidationResult();
        DefaultValidations.ExistingId(item, result, this.crudService);
        DefaultValidations.NotExistingDepedencies(item, result, this.parameterCrudService);
        return result;
    }

    ValidationResult IInsertValidator<ParameterTyp>.Validate(ParameterTyp item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.NotExistingId(item, result, this.crudService);
        return result;
    }

    ValidationResult IUpdateValidator<ParameterTyp>.Validate(ParameterTyp item)
    {
        var result = new ValidationResult();
        DefaultValidations.Name(item, result);
        DefaultValidations.Description(item, result);
        DefaultValidations.ExistingId(item, result, this.crudService);
        return result;
    }
}