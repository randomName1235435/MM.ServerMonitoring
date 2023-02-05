using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers;

public class DefaultBehaviorControllerBase<TEntity, TDto> : ControllerBase
    where TEntity : class, IHasId, new()
{
    protected readonly IDeleteByIdCommand<Guid, TEntity> deleteByIdCommand;
    protected readonly IInsertCommand<TEntity, Guid> insertCommand;
    protected readonly ILogger<DefaultBehaviorControllerBase<TEntity, TDto>> logger;

    protected readonly IMapper<TEntity, TDto> mapper;
    protected readonly IReadByIdCommand<Guid, TEntity> readByIdCommand;

    protected readonly IReadCommand<IEnumerable<TEntity>> readCommand;
    protected readonly IUpdateCommand<TEntity> updateCommand;

    protected DefaultBehaviorControllerBase(
        ICommandFactory<TEntity> commandFactory,
        IMapper<TEntity, TDto> mapper,
        ILogger<DefaultBehaviorControllerBase<TEntity, TDto>> logger)
    {
        _ = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        _ = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _ = logger ?? throw new ArgumentNullException(nameof(logger));

        this.mapper = mapper;
        this.logger = logger;

        this.readCommand = commandFactory.ReadCommand;
        this.readByIdCommand = commandFactory.ReadByIdCommand;
        this.deleteByIdCommand = commandFactory.DeleteByIdCommand;
        this.updateCommand = commandFactory.UpdateCommand;
        this.insertCommand = commandFactory.InsertCommand;
    }

    [HttpGet]
    public virtual async Task<IEnumerable<TDto>> Get(CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var resultCollection = await this.readCommand.ExecuteAsync(cancellationToken);
            var result = resultCollection.Select(item => this.mapper.Map(item));
            return result;
        });
    }

    [HttpGet("{id:guid}")]
    public virtual async Task<TDto> Get(Guid id, CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var item = await this.readByIdCommand.ExecuteAsync(id, cancellationToken);
            var result = this.mapper.Map(item);
            return result;
        });
    }

    [HttpDelete("{id:guid}")]
    public virtual async Task<Guid> Delete(Guid id, CancellationToken cancellationToken)
    {
        await this.WithLogging(async () => { await this.deleteByIdCommand.ExecuteAsync(id, cancellationToken); });
        return id;
    }

    [HttpPost]
    public virtual async Task<Guid> Post(TDto item, CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var model = this.mapper.Map(item);
            var result = await this.insertCommand.ExecuteAsync(model, cancellationToken);
            return result;
        });
    }

    [HttpPut]
    public virtual async Task<Guid> Put(TDto item, CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var model = this.mapper.Map(item);
            return await this.updateCommand.ExecuteAsync(model, cancellationToken);
        });
    }

    private async Task WithLogging(Func<Task> func)
    {
        try
        {
            using var log = Log<DefaultBehaviorControllerBase<TEntity, TDto>>.InfoApiCall(this.logger, Request);
            await func();
        }
        catch (Exception ex)
        {
            this.logger.LogError("requested api call failed [url={0}, exception={1}]", Request.GetDisplayUrl(), ex);
            throw;
        }
    }

    private async Task<TResult> WithLogging<TResult>(Func<Task<TResult>> func)
    {
        try
        {
            using var log = Log<DefaultBehaviorControllerBase<TEntity, TDto>>.InfoApiCall(this.logger, Request);
            return await func();
        }
        catch (Exception ex)
        {
            this.logger.LogError("requested api call failed [url={0}, exception={1}]", Request.GetDisplayUrl(), ex);
            throw;
        }
    }
}