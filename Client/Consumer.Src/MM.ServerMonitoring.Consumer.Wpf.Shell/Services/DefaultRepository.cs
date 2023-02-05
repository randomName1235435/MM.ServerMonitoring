using System;
using System.Collections.Generic;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Services;

public class DefaultRepository<TDto> : IRepository<TDto>
    where TDto : class, IHasId
{
    private readonly IDefaultCrudServiceAsync<TDto, Guid> crudService;

    public DefaultRepository(IDefaultCrudServiceAsync<TDto, Guid> crudService)
    {
        this.crudService = crudService;
    }

    public Guid Delete(Guid id)
    {
        return crudService.DeleteAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public Guid Insert(TDto param)
    {
        return crudService.CreateAsync(param).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public Guid Update(TDto param)
    {
        return crudService.UpdateAsync(param.Id, param).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public IEnumerable<TDto> Read()
    {
        return crudService.GetAllAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public TDto Read(Guid id)
    {
        return crudService.GetAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
    }
}