using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework;

//    //disposing einbauen
public class RepositoryBase<TEntity> : IRepositoryAsync<TEntity>
    where TEntity : class, IHasId
{
    private readonly IDataContextAsync dataContext;

    public RepositoryBase(IDataContextAsync dataContext)
    {
        this.dataContext = dataContext;
    }

    public virtual void Insert(TEntity item)
    {
        var context = this.dataContext;

        using (var transaction = context.BeginTransaction())
        {
            try
            {
                context.Set<TEntity>().Add(item);

                context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public virtual void Update(TEntity item)
    {
        var context = this.dataContext;

        using (var transaction = context.BeginTransaction())
        {
            try
            {
                context.Set<TEntity>().Update(item);

                context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public virtual void Delete(TEntity item)
    {
        var context = this.dataContext;
        using (var transaction = context.BeginTransaction())
        {
            try
            {
                context.Set<TEntity>().Remove(item);

                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public TEntity Find(Func<IQueryable<TEntity>, TEntity> query)
    {
        return query(this.dataContext.Set<TEntity>().AsNoTracking());
    }

    public virtual IQueryable<TEntity> Read(Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
    {
        return query(this.dataContext.Set<TEntity>().AsNoTracking());
    }

    public virtual int Read(Func<IQueryable<TEntity>, int> query)
    {
        return query(this.dataContext.Set<TEntity>().AsNoTracking());
    }

    public virtual IQueryable<TEntity> Read<TProperty>(Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
        Expression<Func<TEntity, TProperty>> includes)
    {
        return query(this.dataContext.Set<TEntity>().Include(includes).AsNoTracking());
    }

    public virtual Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return this.dataContext.Set<TEntity>().FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public virtual TEntity FindById(Guid id)
    {
        return this.dataContext.Set<TEntity>().FirstOrDefault(item => item.Id == id);
    }

    public virtual async Task<IEnumerable<TEntity>> ReadAsync(CancellationToken cancellationToken)
    {
        return await this.dataContext.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public Task<TEntity> FindByIdWithIncludesAsync(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>> addIncludes,
        CancellationToken cancellationToken)
    {
        return addIncludes(this.dataContext.Set<TEntity>().AsQueryable()).AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public virtual async Task<IEnumerable<TEntity>> ReadAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
        CancellationToken cancellationToken)
    {
        return await query(this.dataContext.Set<TEntity>().AsNoTracking()).ToListAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
        CancellationToken cancellationToken)
    {
        return await query(this.dataContext.Set<TEntity>().AsNoTracking()).CountAsync(cancellationToken);
    }

    public virtual async Task InsertAsync(TEntity item, CancellationToken cancellationToken)
    {
        await this.InTransaction(() => this.dataContext.Set<TEntity>().Add(item), cancellationToken);
    }

    public virtual async Task<Guid> UpdateAsync(TEntity item, CancellationToken cancellationToken)
    {
        await this.InTransaction(() => this.dataContext.Set<TEntity>().Update(item), cancellationToken);
        return item.Id;
    }

    public virtual async Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
    {
        await this.InTransaction(
            () => this.dataContext.Set<TEntity>()
                .Remove(this.dataContext.Set<TEntity>().First(first => first.Id == item.Id)), cancellationToken);
    }

    public virtual IQueryable<TEntity> Read()
    {
        return this.dataContext.Set<TEntity>().AsNoTracking();
    }

    public virtual IQueryable<TEntity> Read<TProperty>(Expression<Func<TEntity, TProperty>> includes)
    {
        return this.dataContext.Set<TEntity>().Include(includes).AsNoTracking();
    }

    public virtual async Task<IEnumerable<TEntity>> ReadAsync<TProperty>(Expression<Func<TEntity, TProperty>> includes,
        CancellationToken cancellationToken)
    {
        return await this.dataContext.Set<TEntity>().Include(includes).AsNoTracking().ToListAsync(cancellationToken);
    }

    protected virtual async Task InTransaction(Action toExecute, CancellationToken cancellationToken)
    {
        await using (var transaction = await this.dataContext.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                toExecute();

                await this.dataContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}