using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Commands;

public class DashboardLoadedSucceedEvent : PubSubEvent<DashboardDto>
{
}