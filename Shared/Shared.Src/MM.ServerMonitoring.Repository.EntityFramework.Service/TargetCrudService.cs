using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class TargetCrudService : CrudServiceBase<Target>
{
    public TargetCrudService(IRepositoryAsync<Target> repository) : base(repository)
    {
    }

    protected override IQueryable<Target> AddIncludes(IQueryable<Target> query)
    {
        return query
            .Include(item => item.TargetTyp);
    }
}