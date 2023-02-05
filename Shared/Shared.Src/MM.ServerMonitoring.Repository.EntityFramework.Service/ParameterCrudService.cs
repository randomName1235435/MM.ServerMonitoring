using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class ParameterCrudService : CrudServiceBase<Parameter>
{
    public ParameterCrudService(IRepositoryAsync<Parameter> repository) : base(repository)
    {
    }

    protected override IQueryable<Parameter> AddIncludes(IQueryable<Parameter> query)
    {
        return query
            .Include(item => item.ParameterTyp);
    }
}