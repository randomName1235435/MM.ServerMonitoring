using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Commands;

public class DashboardReadCommand : DataCommandBase<DashboardDto, DashboardLoadedSucceedEvent,
    DataLoadedFailedEvent<DashboardDto>, IDashboardReadRepository>, ICommand
{
    private readonly bool canExecute = true;

    public DashboardReadCommand(IEventAggregator eventAggregator,
        IMessageBoxService messageboxService,
        IDashboardReadRepository repository,
        IDispatcher dispatcher,
        ILogger logger) :
        base(eventAggregator, messageboxService, repository, dispatcher, logger)
    {
    }

    public virtual bool CanExecute(object? parameter)
    {
        return this.canExecute;
    }

    public virtual void Execute(object? parameter)
    {
        this.ExecuteFuncAsync(this.repository.Read);
    }

    public virtual void ExecuteFuncAsync(Func<DashboardDto> toExecute)
    {
        this.NotifyRunning();
        Task.Run(() =>
        {
            try
            {
                this.logger.Info("loading dashboard");
                var result = toExecute();
                this.succeedEvent.Publish(result);
            }
            catch (Exception e) //todo switch validation exception //https status or something..
            {
                this.logger.Exception(e);
                this.messageBoxService.Show(e.Message);
                this.failedEvent.Publish();
            }
            finally
            {
                this.NotifyStopped();
            }
        });
    }
}