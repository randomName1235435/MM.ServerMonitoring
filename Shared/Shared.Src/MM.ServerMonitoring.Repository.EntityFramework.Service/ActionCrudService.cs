using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public class ActionCrudService : CrudServiceBase<Action>
{
    public ActionCrudService(IRepositoryAsync<Action> repository) : base(repository)
    {
    }

    protected override IQueryable<Action> AddIncludes(IQueryable<Action> query)
    {
        return query;
    }
}