using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class MonitorCrudService : CrudServiceBase<Monitor>
{
    public MonitorCrudService(IRepositoryAsync<Monitor> repository) : base(repository)
    {
    }

    protected override IQueryable<Monitor> AddIncludes(IQueryable<Monitor> query)
    {
        return query
            .Include(item => item.Action)
            .Include(item => item.Parameter)
            .Include(item => item.Parameter.ParameterTyp)
            .Include(item => item.Target)
            .Include(item => item.Target.TargetTyp);
    }
}