using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;
using Prism.Mvvm;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.SimpleActionResultView;

public class SimpleActionResultViewModel : BindableBase, IViewModel
{
    private readonly IDispatcher dispatcher;
    private readonly FilterSuccessEventTDto<MonitorActionExecutionDto> filterSuccess;
    private readonly DataLoadedFailedEvent<MonitorActionExecutionDto> loadFailed;
    private readonly DataLoadedSucceedEvent<MonitorActionExecutionDto> loadSucceed;
    private readonly SelectedItemChanged<MonitorActionExecutionDto> selectedItemChanged;

    private ObservableCollection<MonitorActionExecutionDto> items;
    private MonitorActionExecutionDto selectedItem;

    public SimpleActionResultViewModel()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        {
        }
        else
        {
            throw new Exception("only design time");
        }
    }

    public SimpleActionResultViewModel(
        IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        MonitorActionExecutionDtoCommandFactory commandFactory)
    {
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _ = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        _ = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));

        this.dispatcher = dispatcher;

        this.loadFailed = eventAggregator.GetEvent<DataLoadedFailedEvent<MonitorActionExecutionDto>>();
        this.loadSucceed = eventAggregator.GetEvent<DataLoadedSucceedEvent<MonitorActionExecutionDto>>();

        this.filterSuccess = eventAggregator.GetEvent<FilterSuccessEventTDto<MonitorActionExecutionDto>>();
        this.selectedItemChanged = eventAggregator.GetEvent<SelectedItemChanged<MonitorActionExecutionDto>>();

        //todo durchgehende verwendung von view/page create/insert/neu etc
        this.WireEvents();

        LoadCommand = commandFactory.LoadCommand;
        FilterCommand = commandFactory.FilterCommand;
    }

    public ObservableCollection<MonitorActionExecutionDto> Items
    {
        get => this.items;
        set => this.SetProperty(ref this.items, value);
    }

    public ICommand LoadCommand { get; }

    public ICommand FilterCommand { get; }

    public MonitorActionExecutionDto SelectedItem
    {
        get => this.selectedItem;
        set
        {
            this.SetProperty(ref this.selectedItem, value);
            this.selectedItemChanged.Publish(value);
        }
    }

    public virtual void ViewReady()
    {
        LoadCommand.Execute(null);
    }

    private void WireEvents()
    {
        this.loadFailed.Subscribe(this.DataLoadFailed);
        this.loadSucceed.Subscribe(this.DataLoadSucceed);

        this.filterSuccess.Subscribe(this.FilterSuccess);
    }

    private void FilterSuccess(IEnumerable<MonitorActionExecutionDto> obj)
    {
        SelectedItem = default;
        Items = new ObservableCollection<MonitorActionExecutionDto>(obj);
    }

    public void DataLoadSucceed(IEnumerable<MonitorActionExecutionDto> obj)
    {
        Items = new ObservableCollection<MonitorActionExecutionDto>(obj);
    }

    public void DataLoadFailed()
    {
        //disable all edit controls?
        //todo show generic sorry page
    }
}