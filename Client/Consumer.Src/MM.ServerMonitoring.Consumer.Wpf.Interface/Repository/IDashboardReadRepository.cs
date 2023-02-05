using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

namespace MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;

public interface IDashboardReadRepository
{
    DashboardDto Read();
}