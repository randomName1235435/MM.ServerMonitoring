using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Interface;

public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class, IHasId
{
    Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    Task InsertAsync(TEntity item, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(TEntity item, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity item, CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> ReadAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query,
        CancellationToken cancellationToken);

    Task<int> CountAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> ReadAsync(CancellationToken cancellationToken);

    Task<TEntity> FindByIdWithIncludesAsync(Guid id, Func<IQueryable<TEntity>, IQueryable<TEntity>> addIncludes,
        CancellationToken cancellationToken);
}