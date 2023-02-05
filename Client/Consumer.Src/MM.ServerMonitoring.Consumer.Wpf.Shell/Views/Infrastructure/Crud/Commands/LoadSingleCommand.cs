using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;
using Prism.Events;
using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class LoadSingleCommand<TDto> :
    DataCommandBase<TDto, SingleDataLoadedSucceedEvent<TDto>, SingleDataLoadedFailedEvent<TDto>, IReadRepository<TDto>>,
    ICommand where TDto : IHasId
{
    public LoadSingleCommand(
        IEventAggregator eventAggregator,
        IMessageBoxService messageBoxService,
        IReadRepository<TDto> repository,
        IDispatcher dispatcher, ILogger logger
    )
        : base(eventAggregator, messageBoxService, repository, dispatcher, logger)
    {
    }

    public virtual bool CanExecute(object? parameter)
    {
        return !this.isRunning;
    }

    public virtual void Execute(object? parameter)
    {
        if (parameter is not Guid id)
            return;
        this.ExecuteFuncAsync(() => this.repository.Read(id));
    }

    public virtual void ExecuteFuncAsync(Func<TDto> toExecute)
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