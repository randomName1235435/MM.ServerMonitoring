using System;
using System.Linq;
using System.Threading.Tasks;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Command;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using Prism.Events;
using Action = MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud.Action;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

public class LoadMonitorDependentsCommand : ILoadDependentsCommand<Monitor>
{
    private readonly IReadRepository<Action> actionRepository;
    protected readonly IDispatcher dispatcher;
    protected readonly LoadDependentsFailedEvent<MonitorDependents> failedEvent;
    protected readonly IMessageBoxService messageBoxService;
    private readonly IReadRepository<Parameter> parameterRepository;
    private readonly IReadRepository<ParameterTyp> parameterTypRepository;
    protected readonly LoadDependentsSucceedEvent<MonitorDependents> succeedEvent;
    private readonly IReadRepository<Target> targetRepository;
    private readonly IReadRepository<TargetTyp> targetTypRepository;
    private bool canExecute = true;

    public LoadMonitorDependentsCommand(
        IEventAggregator eventAggregator,
        IMessageBoxService messageBoxService,
        IDispatcher dispatcher,
        IReadRepository<Target> targetRepository,
        IReadRepository<Action> actionRepository,
        IReadRepository<Parameter> parameterRepository,
        IReadRepository<ParameterTyp> parameterTypRepository,
        IReadRepository<TargetTyp> targetTypRepository
    )
    {
        _ = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        _ = messageBoxService ?? throw new ArgumentNullException(nameof(eventAggregator));
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(messageBoxService));
        _ = targetRepository ?? throw new ArgumentNullException(nameof(targetRepository));
        _ = actionRepository ?? throw new ArgumentNullException(nameof(actionRepository));
        _ = parameterRepository ?? throw new ArgumentNullException(nameof(parameterRepository));
        _ = parameterTypRepository ?? throw new ArgumentNullException(nameof(parameterTypRepository));
        _ = targetTypRepository ?? throw new ArgumentNullException(nameof(targetTypRepository));

        this.succeedEvent = eventAggregator.GetEvent<LoadDependentsSucceedEvent<MonitorDependents>>();
        this.failedEvent = eventAggregator.GetEvent<LoadDependentsFailedEvent<MonitorDependents>>();
        this.messageBoxService = messageBoxService;
        this.dispatcher = dispatcher;
        this.targetRepository = targetRepository;
        this.actionRepository = actionRepository;
        this.parameterRepository = parameterRepository;
        this.parameterTypRepository = parameterTypRepository;
        this.targetTypRepository = targetTypRepository;
    }

    public virtual bool CanExecute(object? parameter)
    {
        return this.canExecute;
    }

    public virtual void Execute(object? parameter)
    {
        this.UpdateCanExecute(false);
        Task.Run(() =>
        {
            try
            {
                var result = new MonitorDependents();

                result.Parameter = this.parameterRepository.Read()
                    .Select(item => new IdNamePair(item.Id, item.Value));
                result.Actions = this.actionRepository.Read()
                    .Select(item => new IdNamePair(item.Id, item.Name));
                result.Targets = this.targetRepository.Read()
                    .Select(item => new IdNamePair(item.Id, item.Name));
                this.succeedEvent.Publish(result);
            }
            catch (Exception e) //todo switch validation exception //https status or something..
            {
                this.messageBoxService.Show(e.Message);
                this.failedEvent.Publish();
            }
            finally
            {
                this.UpdateCanExecute(true);
            }
        });
    }

    public event EventHandler? CanExecuteChanged;

    protected void UpdateCanExecute(bool updated)
    {
        this.dispatcher.Invoke(() =>
        {
            this.canExecute = updated;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        });
    }
}