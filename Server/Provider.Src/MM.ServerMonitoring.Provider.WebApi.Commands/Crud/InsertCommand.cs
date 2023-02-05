using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Crud;

public class InsertCommand<TEntity, TService> :
    IInsertCommand<TEntity, Guid>
    where TEntity : class, IHasId
    where TService : ICrudServiceAsync<TEntity>
{
    protected readonly TService service;
    private readonly IInsertValidator<TEntity> validator;

    public InsertCommand(TService service, IInsertValidator<TEntity> validator)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));
        _ = validator ?? throw new ArgumentNullException(nameof(validator));

        this.service = service;
        this.validator = validator;
    }

    public virtual async Task<Guid> ExecuteAsync(TEntity item, CancellationToken cancellationToken)
    {
        _ = item ?? throw new ArgumentNullException(nameof(item));
        if (item.Id == Guid.Empty)
            throw new ArgumentException("empty " + nameof(item.Id));

        var validationResult = this.validator.Validate(item);
        if (validationResult.Failed)
            throw new ValidationFailedException(validationResult);

        await this.service.InsertAsync(item, cancellationToken);
        return item.Id;
    }

    public virtual Guid Execute(TEntity item)
    {
        _ = item ?? throw new ArgumentNullException(nameof(item));
        if (item.Id == Guid.Empty)
            throw new ArgumentException("empty " + nameof(item.Id));

        var validationResult = this.validator.Validate(item);
        if (validationResult.Failed)
            throw new ValidationFailedException(validationResult);

        this.service.Insert(item);
        return item.Id;
    }
}