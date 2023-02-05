using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Interface.Command;

public interface IMonitorReadCommand : IReadCommand<IEnumerable<Monitor>>
{
}