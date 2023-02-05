using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Commands;

public class LoadParameterCommand : LoadDependentBaseCommand<Parameter>
{
    public LoadParameterCommand(
        IEventAggregator eventAggregator,
        IMessageBoxService messageBoxService,
        IReadRepository<Parameter> repository,
        IDispatcher dispatcher,
        ILogger logger) :
        base(eventAggregator, messageBoxService, repository, dispatcher, logger)
    {
    }
}