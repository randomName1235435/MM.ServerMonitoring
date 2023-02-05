using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;

namespace MM.ServerMonitoring.Provider.WebApi.Interface.Validator;

public interface IInsertValidator<TEntity> : IValidator<TEntity>
{
    //EnsureDependenciesExist
    //ValidationResult DependenciesExist(TEntity item);
    ValidationResult Validate(TEntity item);
    //Task<ValidationResult> ValidateAsync(TEntity item, CancellationToken cancellationToken);
}