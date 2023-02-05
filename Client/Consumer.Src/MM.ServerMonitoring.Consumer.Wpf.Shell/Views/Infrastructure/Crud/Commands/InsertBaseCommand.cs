using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using Prism.Events;
using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class InsertBaseCommand<TDto> :
    DataCommandBase<TDto, InsertSucceedEvent<TDto>, InsertFailedEvent<TDto>, IInsertRepository<TDto>>,
    ICommand
{
    public InsertBaseCommand(IEventAggregator eventAggregator,
        IMessageBoxService messageboxService,
        IInsertRepository<TDto> repository,
        IDispatcher dispatcher, ILogger logger)
        : base(eventAggregator, messageboxService, repository, dispatcher, logger)
    {
    }

    public virtual bool CanExecute(object parameter)
    {
        return !this.isRunning;
    }

    public virtual void Execute(object? parameter)
    {
        if (parameter == null) return;
        var param = (TDto)parameter;

        this.NotifyRunning();
        Task.Run(() =>
        {
            try
            {
                this.repository.Insert(param);
                this.succeedEvent.Publish(param);
            }
            catch (ApiException e)
            {
                this.logger.Exception(e);
                this.messageBoxService.Show(e.Message + Environment.NewLine + "details: " + e.Content);
                this.failedEvent.Publish(param);
            }
            catch (Exception e)
            {
                this.logger.Exception(e);
                this.messageBoxService.Show(e.Message);
                this.failedEvent.Publish(param);
            }
            finally
            {
                this.NotifyStopped();
            }
        });

        //todo shoenere messagebox, vllt einfliegend von oben oder so?
    }
}