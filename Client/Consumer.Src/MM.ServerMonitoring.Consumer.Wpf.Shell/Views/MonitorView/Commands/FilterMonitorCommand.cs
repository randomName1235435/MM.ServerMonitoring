using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Commands;

public class FilterMonitorCommand : FilterBaseCommand<MonitorDto>
{
    public FilterMonitorCommand(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }

    protected override bool Match(MonitorDto item, string filterString)
    {
        return item.Id.ToString().Contains(filterString) ||
               item.Action.Name.Contains(filterString) ||
               item.Description.Contains(filterString) ||
               item.Name.Contains(filterString) ||
               item.Target.Name.Contains(filterString);
    }
}