using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Commands;

public class LoadDependentBaseCommand<TDto> : LoadBaseCommand<TDto>
{
    public LoadDependentBaseCommand(
        IEventAggregator eventAggregator,
        IMessageBoxService messageBoxService,
        IReadRepository<TDto> repository,
        IDispatcher dispatcher, ILogger logger)
        : base(eventAggregator, messageBoxService, repository, dispatcher, logger)
    {
    }
}