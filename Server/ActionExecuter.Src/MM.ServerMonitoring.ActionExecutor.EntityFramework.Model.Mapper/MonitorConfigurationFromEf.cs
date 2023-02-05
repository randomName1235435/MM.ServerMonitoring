using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.ActionExecutor.EntityFramework.Model.Mapper;

public class MonitorConfigurationFromEf : IMonitorConfiguration
{
    private readonly IMapper<Monitor, MonitorConfiguration> mapper;
    private readonly IRepositoryAsync<Monitor> repository;

    public MonitorConfigurationFromEf(IRepositoryAsync<Monitor> repository,
        IMapper<Monitor, MonitorConfiguration> mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<MonitorConfiguration>> GetAsync(CancellationToken cancellationToken)
    {
        var result = await this.repository.ReadAsync(cancellationToken);

        return result.Select(item => this.mapper.Map(item));
    }
}