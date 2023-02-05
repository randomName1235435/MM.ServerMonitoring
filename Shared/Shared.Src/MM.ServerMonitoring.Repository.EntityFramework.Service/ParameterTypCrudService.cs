using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class ParameterTypCrudService : CrudServiceBase<ParameterTyp>
{
    public ParameterTypCrudService(IRepositoryAsync<ParameterTyp> repository) : base(repository)
    {
    }

    protected override IQueryable<ParameterTyp> AddIncludes(IQueryable<ParameterTyp> query)
    {
        return query;
    }
}