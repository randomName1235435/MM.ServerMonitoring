using MM.ServerMonitoring.Repository.EntityFramework.Infrastructure;

namespace MM.ServerMonitoring.Repository.EntityFramework.Interface;

public interface IQueryService<T>
{
    IEnumerable<T> Read(Func<IQueryable<T>, IQueryable<T>> fn = null);

    Page<T> Read(QueryParameters parameters, Func<IQueryable<T>, IQueryable<T>> fn = null);

    int GetCount(QueryParameters parameters, Func<IQueryable<T>, IQueryable<T>> fn = null);
}