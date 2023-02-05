using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Command;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Extensions;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using Prism.Events;
using Prism.Mvvm;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;

/// <summary>
///     viewmodel base for monitor edit/insert viewmodel
/// </summary>
/// <typeparam name="TSaveCommand"></typeparam>
public abstract class MonitorEditInsertViewModelBase<TSaveCommand> : BindableBase
    where TSaveCommand : ICommand
{
    protected readonly IDispatcher dispatcher;
    protected readonly ILoadDependentsCommand<Monitor> loadDependentsCommand;
    protected ObservableCollection<IdNamePair> actionList;
    protected Monitor editItem;
    protected ObservableCollection<IdNamePair> parameterList;
    private ICommand saveCommand;
    protected Visibility savedSuccessfulTextBlockVisibility = Visibility.Hidden;
    protected IdNamePair selectedAction;
    protected IdNamePair selectedParameter;
    protected IdNamePair selectedTarget;
    protected ObservableCollection<IdNamePair> targetList;


    protected MonitorEditInsertViewModelBase()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            TargetList = new ObservableCollection<IdNamePair>
            {
                new(Guid.NewGuid(), string.Empty),
                new(Guid.NewGuid(), Guid.NewGuid().ToString())
            };
        else
            throw new Exception("only design time");
    }


    protected MonitorEditInsertViewModelBase(
        IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        ILoadDependentsCommand<Monitor> loadDependentsCommand,
        TSaveCommand saveCommand
    )
    {
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _ = loadDependentsCommand ?? throw new ArgumentNullException(nameof(loadDependentsCommand));
        _ = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        _ = saveCommand ?? throw new ArgumentNullException(nameof(saveCommand));

        this.dispatcher = dispatcher;
        this.loadDependentsCommand = loadDependentsCommand;

        eventAggregator.GetEvent<LoadDependentsSucceedEvent<MonitorDependents>>().Subscribe(this.LoadDependentsSucceed);
        eventAggregator.GetEvent<LoadDependentsFailedEvent<MonitorDependents>>().Subscribe(this.LoadDependentsFailed);

        this.saveCommand = saveCommand;
    }

    public ICommand SaveCommand
    {
        get => this.saveCommand;
        set => this.SetProperty(ref this.saveCommand, value);
    }

    public ObservableCollection<IdNamePair> ActionList
    {
        get => this.actionList;
        set => this.SetProperty(ref this.actionList, value);
    }

    public ObservableCollection<IdNamePair> TargetList
    {
        get => this.targetList;
        set => this.SetProperty(ref this.targetList, value);
    }

    public ObservableCollection<IdNamePair> ParameterList
    {
        get => this.parameterList;
        set => this.SetProperty(ref this.parameterList, value);
    }

    public Visibility SavedSuccessfulTextBlockVisibility
    {
        get => this.savedSuccessfulTextBlockVisibility;
        set => this.SetProperty(ref this.savedSuccessfulTextBlockVisibility, value);
    }

    public IdNamePair SelectedAction
    {
        get => this.selectedAction;
        set
        {
            this.SetProperty(ref this.selectedAction, value);
            if (this.selectedAction == null)
                return;
            EditItem.ActionId = this.selectedAction.Id;
        }
    }

    public IdNamePair SelectedTarget
    {
        get => this.selectedTarget;
        set
        {
            this.SetProperty(ref this.selectedTarget, value);
            if (this.selectedTarget == null)
                return;
            EditItem.TargetId = this.selectedTarget.Id;
        }
    }

    public Monitor EditItem
    {
        get => this.editItem;
        set => this.SetProperty(ref this.editItem, value);
    }

    public IdNamePair SelectedParameter
    {
        get => this.selectedParameter;
        set
        {
            this.SetProperty(ref this.selectedParameter, value);
            if (this.selectedParameter == null)
                return;
            EditItem.ParameterId = this.selectedParameter.Id;
        }
    }

    public void ViewReady()
    {
        this.loadDependentsCommand.Execute(null);
    }

    protected virtual void LoadDependentsSucceed(MonitorDependents obj)
    {
        this.dispatcher.Invoke(() =>
        {
            ActionList = new ObservableCollection<IdNamePair>(obj.Actions);
            TargetList = new ObservableCollection<IdNamePair>(obj.Targets);
            ParameterList = new ObservableCollection<IdNamePair>(obj.Parameter);
        });
    }

    protected virtual void LoadDependentsFailed()
    {
        this.dispatcher.Invoke(() =>
        {
            ActionList = Empty.ObservableCollection<IdNamePair>();
            TargetList = Empty.ObservableCollection<IdNamePair>();
            ParameterList = Empty.ObservableCollection<IdNamePair>();
        });
    }

    protected void SaveFailed(Monitor obj)
    {
        SavedSuccessfulTextBlockVisibility = Visibility.Hidden;
    }

    protected void SaveSucceed(Monitor obj)
    {
        SavedSuccessfulTextBlockVisibility = Visibility.Visible;

        EditItem = new Monitor { Id = Guid.NewGuid() };
        SelectedAction = null;
        SelectedParameter = null;
        SelectedTarget = null;
    }
}