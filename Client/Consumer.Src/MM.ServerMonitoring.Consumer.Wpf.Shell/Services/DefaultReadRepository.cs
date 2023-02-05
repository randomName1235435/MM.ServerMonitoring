using System;
using System.Collections.Generic;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Services;

public class DefaultReadRepository<TDto> : IReadRepository<TDto>
    where TDto : class, IHasId
{
    private readonly IDefaultReadServiceAsync<TDto, Guid> crudService;
    private readonly ILogger logger;

    public DefaultReadRepository(ILogger logger, IDefaultReadServiceAsync<TDto, Guid> crudService)
    {
        this.logger = logger;
        this.crudService = crudService;
    }

    public IEnumerable<TDto> Read()
    {
        try
        {
            return crudService.GetAllAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            logger.Exception(e);
            throw;
        }
    }

    public TDto Read(Guid id)
    {
        try
        {
            return crudService.GetAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            logger.Exception(e);
            throw;
        }
    }
}