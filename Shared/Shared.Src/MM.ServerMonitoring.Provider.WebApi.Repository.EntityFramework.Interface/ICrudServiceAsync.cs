using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Interface;

public interface ICrudServiceAsync<TType> : ICrudService<TType> where TType : class, IHasId
{
    Task<TType> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<TType> FindByIdWithIncludesAsync(Guid id, CancellationToken cancellationToken);
    Task InsertAsync(TType item, CancellationToken cancellationToken);
    Task<Guid> UpdateAsync(TType item, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TType>> ReadAsync(CancellationToken cancellationToken);

    Task<IEnumerable<TType>> ReadAsync(Func<IQueryable<TType>, IEnumerable<TType>> query,
        CancellationToken cancellationToken);

    Task<IEnumerable<TType>> ReadWithIncludesAsync(CancellationToken cancellationToken);

    Task<IEnumerable<TType>> ReadWithIncludesAsync(Func<IQueryable<TType>, IEnumerable<TType>> query,
        CancellationToken cancellationToken);
}