using MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;

namespace MM.ServerMonitoring.Repository.EntityFramework.Interface;

public interface IDashboardService
{
    Dashboard Read();
    Task<Dashboard> ReadAsync(CancellationToken cancellationToken);
}