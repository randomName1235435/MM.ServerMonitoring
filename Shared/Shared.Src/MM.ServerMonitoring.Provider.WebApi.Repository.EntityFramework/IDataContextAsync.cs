using Microsoft.EntityFrameworkCore.Storage;

namespace MM.ServerMonitoring.Repository.EntityFramework;

public interface IDataContextAsync : IDataContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}