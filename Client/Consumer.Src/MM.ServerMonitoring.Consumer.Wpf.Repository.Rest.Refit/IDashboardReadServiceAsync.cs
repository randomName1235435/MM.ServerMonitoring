using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;

public interface IDashboardReadServiceAsync
{
    [Get("")]
    Task<DashboardDto> GetAsync();
}