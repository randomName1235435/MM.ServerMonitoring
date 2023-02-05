using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using Prism.Events;
using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class LoadBaseCommand<TDto> :
    DataCommandBase<TDto, DataLoadedSucceedEvent<TDto>, DataLoadedFailedEvent<TDto>, IReadRepository<TDto>>, ICommand
{
    public LoadBaseCommand(
        IEventAggregator eventAggregator,
        IMessageBoxService messageboxService,
        IReadRepository<TDto> repository,
        IDispatcher dispatcher, ILogger logger
    )
        : base(eventAggregator, messageboxService, repository, dispatcher, logger)
    {
    }

    public virtual bool CanExecute(object? parameter)
    {
        return !this.isRunning;
    }

    public virtual void Execute(object? parameter)
    {
        this.ExecuteFuncAsync(this.repository.Read);
    }

    public virtual void ExecuteFuncAsync(Func<IEnumerable<TDto>> toExecute)
    {
        this.NotifyRunning();
        Task.Run(() =>
        {
            try
            {
                this.logger.Info($"{nameof(this.ExecuteFuncAsync)}`{nameof(TDto)}: executing {toExecute.ToString()}");
                var result = toExecute();
                this.succeedEvent.Publish(result);
            }
            catch (ApiException e)
            {
                this.logger.Exception(e);
                this.messageBoxService.Show(e.Message + Environment.NewLine + "details: " + e.Content);
                this.failedEvent.Publish();
            }
            catch (Exception e) //todo switch validation exception 
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