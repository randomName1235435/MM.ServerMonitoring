using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Interface;

public interface IMonitorService : ICrudServiceAsync<Monitor>, IQueryService<Monitor> //IDataService<Monitor>
{
}

//todo add validators