using System;
using System.Threading.Tasks;
using System.Windows;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Command;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;
using Prism.Events;
using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class DeleteBaseCommand<TDto, TRepository> :
    DataCommandBase<TDto, DeleteSucceedEvent<TDto>, DeleteFailedEvent<TDto>, IDeleteRepository<TRepository>>,
    IDeleteCommand<TDto, TRepository> where TDto : IHasId
{
    public DeleteBaseCommand(IEventAggregator eventAggregator,
        IMessageBoxService messageboxService,
        IDeleteRepository<TRepository> repository,
        IDispatcher dispatcher, ILogger logger)
        : base(eventAggregator, messageboxService, repository, dispatcher, logger)
    {
    }

    public virtual bool CanExecute(object parameter)
    {
        //todo  this.dataLoadFailedEvent = eventAggregator.GetEvent<DataLoadedFailedEvent<TDto>>(); < TLoad> abfangen und dann alle commands deaktivieren
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
                if (this.messageBoxService.Show("sure?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    this.repository.Delete(param.Id);
                    this.succeedEvent.Publish(param);
                }
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
                this.messageBoxService.Show(e.Message + Environment.NewLine + "details: ");
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