using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;

namespace MM.ServerMonitoring.Provider.WebApi.Interface.Validator;

public interface IDeleteValidator<TEntity> : IValidator<TEntity>
{
    //ValidationResult HasDependencies(TEntity item);
    ValidationResult Validate(TEntity item);
    //Task<ValidationResult> ValidateAsync(TEntity item, CancellationToken cancellationToken);
}