using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Model;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.StartupLocation;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Views;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;
using static MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Views.ViewsCollection;
using IContainer = MM.ServerMonitoring.Consumer.Wpf.Interface.IContainer;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell;

public class ShellViewModel : ShellViewModelBase, IViewModel
{
    private readonly IEnvironmentConfiguration configuration;
    private readonly DashboardReadCommand dashboardReadCommand;
    private readonly IDispatcher dispatcher;
    private readonly IEventAggregator eventAggregator;
    private int countActions;
    private int countFailed;
    private int countFailedLastHour;

    private int countMonitor;
    private int countResults;

    private int countSuccess;

    private string errorMessage;
    private Control logView;
    private ViewViewModel selectedTab;
    private ObservableCollection<ViewViewModel> viewItems;
    private WindowLocationViewModel windowLocationViewModel;

    public ShellViewModel() : base(null)
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            try
            {
                ViewItems = new ObservableCollection<ViewViewModel>(DesignTime().Select(viewInfo =>
                    new ViewViewModel(viewInfo.ViewName, viewInfo.IconChar,
                        viewInfo.GetView(null))).ToList());
                SelectedTab = ViewItems.FirstOrDefault();
                LogView = DesignTimeLogView().GetView(null);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        else
            throw new Exception("only design time");
    }

    public ShellViewModel(
        IContainer container,
        IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        IEnvironmentConfiguration configuration,
        DashboardReadCommand dashboardReadCommand) : base(container)
    {
        _ = dashboardReadCommand ?? throw new ArgumentNullException(nameof(dashboardReadCommand));
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _ = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

        this.eventAggregator = eventAggregator;
        this.dispatcher = dispatcher;
        this.configuration = configuration;
        this.dashboardReadCommand = dashboardReadCommand;

        ViewItems = new ObservableCollection<ViewViewModel>(
            All().Select(viewInfo =>
                new ViewViewModel(
                    viewInfo.ViewName,
                    viewInfo.IconChar,
                    viewInfo.GetView(container)
                )).ToList());
        SelectedTab = ViewItems.FirstOrDefault();
    }

    public WindowLocationViewModel WindowLocationViewModel
    {
        get => this.windowLocationViewModel;
        set => this.SetProperty(ref this.windowLocationViewModel, value);
    }

    public Control LogView
    {
        get => this.logView;
        set => this.SetProperty(ref this.logView, value);
    }

    public int CountMonitor
    {
        get => this.countMonitor;
        set => this.SetProperty(ref this.countMonitor, value);
    }

    public int CountResults
    {
        get => this.countResults;
        set => this.SetProperty(ref this.countResults, value);
    }

    public int CountActions
    {
        get => this.countActions;
        set => this.SetProperty(ref this.countActions, value);
    }

    public int CountFailed
    {
        get => this.countFailed;
        set => this.SetProperty(ref this.countFailed, value);
    }

    public int CountFailedLastHour
    {
        get => this.countFailedLastHour;
        set => this.SetProperty(ref this.countFailedLastHour, value);
    }

    public int CountSuccess
    {
        get => this.countSuccess;
        set => this.SetProperty(ref this.countSuccess, value);
    }

    public string ErrorMessage
    {
        get => this.errorMessage;
        set => this.SetProperty(ref this.errorMessage, value);
    }

    public ViewViewModel SelectedTab
    {
        get => this.selectedTab;
        set => this.SetProperty(ref this.selectedTab, value);
    }

    public ObservableCollection<ViewViewModel> ViewItems
    {
        get => this.viewItems;
        set => this.SetProperty(ref this.viewItems, value);
    }

    public void ViewReady()
    {
        LogView = ViewsCollection.LogView().GetView(this.container);

        this.eventAggregator.GetEvent<DashboardLoadedSucceedEvent>().Subscribe(this.DashboardLoaded);

        this.dashboardReadCommand.Execute(null);
        WindowLocationViewModel = this.configuration.Get().MainWindowStartupLocation switch
        {
            MainWindowStartupLocation.Left => new LeftWindowLocationViewModel(),
            MainWindowStartupLocation.Right => new RightWindowLocationViewModel(),
            MainWindowStartupLocation.Maximized => new MaximizedWindowLocationViewModel(),
            _ => new MaximizedWindowLocationViewModel()
        };
    }

    private void DashboardLoaded(DashboardDto obj)
    {
        this.dispatcher.Invoke(() =>
        {
            CountSuccess = obj.CountSuccess;
            CountMonitor = obj.CountMonitor;
            CountResults = obj.CountResults;
            CountActions = obj.CountActions;
            CountFailed = obj.CountFailed;
            CountFailedLastHour = obj.CountFailedLastHour;
        });
    }

    public void ViewClosed()
    {
    }
}