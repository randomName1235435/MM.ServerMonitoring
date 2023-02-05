using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class MonitorActionExecutionCrudService : CrudServiceBase<MonitorActionExecution>
{
    public MonitorActionExecutionCrudService(IRepositoryAsync<MonitorActionExecution> repository) : base(repository)
    {
    }

    protected override IQueryable<MonitorActionExecution> AddIncludes(IQueryable<MonitorActionExecution> query)
    {
        return query
            .Include(item => item.Action)
            .Include(item => item.Monitor)
            .Include(item => item.Monitor.Parameter)
            .Include(item => item.Monitor.Parameter.ParameterTyp)
            .Include(item => item.Target)
            .Include(item => item.Target.TargetTyp);
    }
}