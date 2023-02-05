using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class TargetTypCrudService : CrudServiceBase<TargetTyp>
{
    public TargetTypCrudService(IRepositoryAsync<TargetTyp> repository) : base(repository)
    {
    }

    protected override IQueryable<TargetTyp> AddIncludes(IQueryable<TargetTyp> query)
    {
        return query;
    }
}