using System.Linq.Expressions;

namespace MM.ServerMonitoring.Repository.EntityFramework.Interface;

public interface IRepository<TEntity> where TEntity : class
{
    void Insert(TEntity item);
    void Update(TEntity item);
    void Delete(TEntity item);
    TEntity Find(Func<IQueryable<TEntity>, TEntity> query);
    TEntity FindById(Guid id);
    IQueryable<TEntity> Read(Func<IQueryable<TEntity>, IQueryable<TEntity>> query);
    int Read(Func<IQueryable<TEntity>, int> query);
    IQueryable<TEntity> Read();

    IQueryable<TEntity> Read<TProperty>(Expression<Func<TEntity, TProperty>> includes);

    IQueryable<TEntity> Read<TProperty>(Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
        Expression<Func<TEntity, TProperty>> includes);
}