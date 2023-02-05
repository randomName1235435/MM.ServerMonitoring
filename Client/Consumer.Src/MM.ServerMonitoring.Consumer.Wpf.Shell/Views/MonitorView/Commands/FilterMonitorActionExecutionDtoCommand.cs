using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Commands;

public class FilterMonitorActionExecutionDtoCommand : FilterBaseCommand<MonitorActionExecutionDto>
{
    public FilterMonitorActionExecutionDtoCommand(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }

    protected override bool Match(MonitorActionExecutionDto item, string filterString)
    {
        return item.Id.ToString().Contains(filterString) ||
               item.Action.Name.Contains(filterString) ||
               item.Monitor.Name.Contains(filterString) ||
               item.Parameter.Value.Contains(filterString) ||
               item.Finish.ToShortDateString().Contains(filterString) ||
               item.Start.ToShortDateString().Contains(filterString) ||
               item.Target.Name.Contains(filterString);
    }
}