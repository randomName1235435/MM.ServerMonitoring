using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Commands;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;

public class MonitorActionExecutionDtoCommandFactory : ReadOnlyCommandFactoryBase
{
    //todo: maybe use separate interface for each command so u can mock them?
    public MonitorActionExecutionDtoCommandFactory(
        LoadBaseCommand<MonitorActionExecutionDto> readCommand,
        FilterMonitorActionExecutionDtoCommand filterCommand) :
        base(
            readCommand,
            filterCommand)
    {
    }
}