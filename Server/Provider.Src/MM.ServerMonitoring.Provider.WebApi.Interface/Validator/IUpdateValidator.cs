using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;

namespace MM.ServerMonitoring.Provider.WebApi.Interface.Validator;

public interface IUpdateValidator<TEntity> : IValidator<TEntity>
{
    ValidationResult Validate(TEntity item);
    //Task<ValidationResult> ValidateAsync(TEntity item, CancellationToken cancellationToken);
    //EnsureDependenciesExist
    //ValidationResult DependenciesExist(TEntity item);
}