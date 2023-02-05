using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Service;

public abstract class CrudServiceBase<T> : QueryServiceBase<T>, ICrudServiceAsync<T>
    where T : class, IHasId
{
    protected readonly IRepositoryAsync<T> repository;

    public CrudServiceBase(IRepositoryAsync<T> repository)
    {
        _ = repository ?? throw new ArgumentNullException(nameof(repository));
        this.repository = repository;
    }

    public virtual T FindById(Guid id)
    {
        return this.repository.FindById(id);
    }

    public virtual T FindByIdWithIncludes(Guid id)
    {
        return this.AddIncludes(this.repository.Read()).FirstOrDefault(item => item.Id == id);
    }

    public virtual IEnumerable<T> Read()
    {
        return this.repository.Read().ToList();
    }

    public virtual IEnumerable<T> Read(Func<IQueryable<T>, IEnumerable<T>> query)
    {
        return query(this.repository.Read()).ToList();
    }

    public virtual IEnumerable<T> ReadWithIncludes()
    {
        return this.AddIncludes(this.repository.Read()).ToList();
    }

    public IEnumerable<T> ReadWithIncludes(Func<IQueryable<T>, IEnumerable<T>> query)
    {
        return query(this.AddIncludes(this.repository.Read())).ToList();
    }


    public virtual void Delete(Guid id)
    {
        var itemToDelete = this.Read(id);
        if (itemToDelete == null)
            return;
        lock (this.@lock)
        {
            this.repository.Delete(itemToDelete);
        }
    }

    public virtual async Task<IEnumerable<T>> ReadAsync(Func<IQueryable<T>, IEnumerable<T>> query,
        CancellationToken cancellationToken)
    {
        return await this.repository.ReadAsync(collection => query(collection).AsQueryable(), cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> ReadWithIncludesAsync(CancellationToken cancellationToken)
    {
        return await this.repository.ReadAsync(this.AddIncludes, cancellationToken);
    }

    public async Task<IEnumerable<T>> ReadWithIncludesAsync(Func<IQueryable<T>, IEnumerable<T>> query,
        CancellationToken cancellationToken)
    {
        return await this.repository.ReadAsync(collection => query(this.AddIncludes(collection)).AsQueryable(),
            cancellationToken);
    }

    public virtual Guid Update(T item)
    {
        lock (this.@lock)
        {
            this.repository.Update(item);
        }

        return item.Id;
    }


    public virtual void Insert(T item)
    {
        lock (this.@lock)
        {
            this.repository.Insert(item);
        }
    }

    public virtual Task<T> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return this.repository.FindByIdAsync(id, cancellationToken);
    }

    public virtual Task<T> FindByIdWithIncludesAsync(Guid id, CancellationToken cancellationToken)
    {
        return this.repository.FindByIdWithIncludesAsync(id, this.AddIncludes, cancellationToken);
    }

    public virtual Task InsertAsync(T item, CancellationToken cancellationToken)
    {
        lock (this.@lock)
        {
            return this.repository.InsertAsync(item, cancellationToken);
        }
    }

    public virtual Task<Guid> UpdateAsync(T item, CancellationToken cancellationToken)
    {
        lock (this.@lock)
        {
            return this.repository.UpdateAsync(item, cancellationToken);
        }
    }

    public virtual Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var itemToDelete = this.Read(id);
        if (itemToDelete == null)
            return Task.CompletedTask;
        //todo check fk? 
        lock (this.@lock)
        {
            return this.repository.DeleteAsync(itemToDelete, cancellationToken);
        }
    }

    public virtual async Task<IEnumerable<T>> ReadAsync(CancellationToken cancellationToken)
    {
        return await this.repository.ReadAsync(cancellationToken);
    }

    protected virtual IQueryable<T> AddIncludes(IQueryable<T> query)
    {
        return query;
    }

    public virtual T Read(Guid id)
    {
        return this.repository.Read().FirstOrDefault(item => item.Id == id);
    }

    public virtual T Read(Func<IQueryable<T>, T> query)
    {
        return query(this.repository.Read());
    }

    protected override IQueryable<T> ReadInternal()
    {
        return this.repository.Read();
    }

    protected override IQueryable<T> FilterByQuery(IQueryable<T> query, string filter)
    {
        return query;
    }

    protected override IQueryable<T> EstablishNaturalOrder(IQueryable<T> query)
    {
        return query.OrderBy(item => item.Id);
    }
}