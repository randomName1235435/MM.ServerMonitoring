using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Provider.WebApi.Interface.Validator;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Commands.Crud;

public class DeleteByIdCommand<TEntity, TService> :
    IDeleteByIdCommand<Guid, TEntity>
    where TEntity : class, IHasId
    where TService : ICrudServiceAsync<TEntity>
{
    protected readonly TService service;
    private readonly IDeleteValidator<TEntity> validator;

    public DeleteByIdCommand(TService service, IDeleteValidator<TEntity> validator)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));
        _ = validator ?? throw new ArgumentNullException(nameof(validator));

        this.service = service;
        this.validator = validator;
    }

    //todo validator async bauen und einbauen
    public virtual async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var item = await this.service.FindByIdAsync(id, cancellationToken);
        if (item == null)
            throw new ItemNotFoundException(id.ToString());

        var validationResult = this.validator.Validate(item);
        if (validationResult.Failed)
            throw new ValidationFailedException(validationResult);
        await this.service.DeleteAsync(id, cancellationToken);
    }

    public virtual void Execute(Guid id)
    {
        var item = this.service.FindById(id);
        if (item == null)
            throw new ItemNotFoundException(id.ToString());

        var validationResult = this.validator.Validate(item);
        if (validationResult.Failed)
            throw new ValidationFailedException(validationResult);
        this.service.Delete(id);
    }
}