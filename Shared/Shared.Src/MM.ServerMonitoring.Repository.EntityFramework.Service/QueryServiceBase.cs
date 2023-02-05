using MM.ServerMonitoring.Repository.EntityFramework.Infrastructure;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

//todo querybase mit repository zusammen bringen?
public abstract class QueryServiceBase<T> : IQueryService<T> where T : class
{
    protected readonly object @lock = new();

    public virtual IEnumerable<T> Read(Func<IQueryable<T>, IQueryable<T>> fn = null)
    {
        return this.Read(null, fn).Items;
    }

    public virtual Page<T> Read(QueryParameters parameters, Func<IQueryable<T>, IQueryable<T>> fn = null)
    {
        var query = parameters?.Query;
        var pageIndex = parameters?.PageIndex ?? 0;
        var pageSize = parameters?.PageSize ?? 0;

        lock (this.@lock)
        {
            var results = this.EstablishNaturalOrder(this.ReadInternal())
                .ApplyIfNotNull(fn);

            if (!string.IsNullOrEmpty(query)) results = this.FilterByQuery(results, query);

            var count = results.Count();
            var pageCount = 1;

            if (pageIndex >= 0 && pageSize > 0)
            {
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
                pageCount = Math.Max(1, count / pageSize);
            }

            return new Page<T>
            {
                Items = results.ToList(),
                PageIndex = pageIndex,
                PageCount = pageCount
            };
        }
    }

    public int GetCount(QueryParameters parameters, Func<IQueryable<T>, IQueryable<T>> fn = null)
    {
        var query = parameters?.Query;

        lock (this.@lock)
        {
            var results = this.ReadInternal();

            if (fn != null) results = fn(results);

            if (!string.IsNullOrEmpty(query)) results = this.FilterByQuery(results, query);

            return results.Count();
        }
    }

    protected abstract IQueryable<T> ReadInternal();

    protected abstract IQueryable<T> FilterByQuery(IQueryable<T> query, string filter);

    protected abstract IQueryable<T> EstablishNaturalOrder(IQueryable<T> query);
}