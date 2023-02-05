using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Command;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.IocContainer.LightInject;
using MM.ServerMonitoring.Consumer.Wpf.Logging;
using MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Configuration.Configuration;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Services;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.LogView;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Edit;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Insert;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.SimpleActionResultView;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;
using Refit;
using Action = MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud.Action;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell;

public class Bootstrapper
{
    private IContainer rootContainer;

    internal void Run()
    {
        var eventAggregator = new EventAggregator();
        var logger = SimpleEventLogger.Create(eventAggregator);
        this.rootContainer = ContainerFactory.Create(logger);

        this.rootContainer.RegisterInstance<IEventAggregator>(eventAggregator);
        this.rootContainer.RegisterInstance<IReadableLogger>(logger);
        this.ConfigureContainer();
        var shell = this.CreateShell();
        StartApp(shell);
    }

    private Window CreateShell()
    {
        return this.rootContainer.Resolve<ShellWindow>();
    }

    private void ConfigureContainer()
    {
        this.AddRestServices();
        this.rootContainer.Register<IDispatcher, Dispatcher>();
        this.rootContainer.Register<IMessageBoxService, MessageBoxService>();

        this.rootContainer.Register<IReadRepository<TargetTyp>, DefaultReadRepository<TargetTyp>>();
        this.rootContainer.Register<IReadRepository<ParameterTyp>, DefaultReadRepository<ParameterTyp>>();
        this.rootContainer.Register<IReadRepository<MonitorDto>, DefaultReadRepository<MonitorDto>>();
        this.rootContainer
            .Register<IReadRepository<MonitorActionExecutionDto>, DefaultReadRepository<MonitorActionExecutionDto>>();
        this.rootContainer.Register<IReadRepository<Target>, DefaultReadRepository<Target>>();
        this.rootContainer.Register<IReadRepository<Parameter>, DefaultReadRepository<Parameter>>();
        this.rootContainer.Register<IReadRepository<Action>, DefaultReadRepository<Action>>();

        this.rootContainer.RegisterType<LoadTargetsCommand>();

        this.rootContainer.Register<IDashboardReadRepository, DashboardReadRepository>();

        this.rootContainer.Register<IEnvironmentConfiguration, EnvironmentConfigurationFromHardCoded>();

        this.rootContainer.Register<IRepository<Monitor>, DefaultRepository<Monitor>>();
        this.rootContainer.Register<IReadRepository<Monitor>, DefaultRepository<Monitor>>();
        this.rootContainer.Register<IDeleteRepository<Monitor>, DefaultRepository<Monitor>>();
        this.rootContainer.Register<IInsertRepository<Monitor>, DefaultRepository<Monitor>>();
        this.rootContainer.Register<IUpdateRepository<Monitor>, DefaultRepository<Monitor>>();

        this.rootContainer.RegisterType<LoadBaseCommand<Monitor>>();
        this.rootContainer.RegisterType<FilterMonitorCommand>();
        this.rootContainer.RegisterType<FilterMonitorActionExecutionDtoCommand>();
        this.rootContainer.RegisterType<LoadSingleCommand<MonitorDto>>();
        this.rootContainer.RegisterType<UpdateBaseCommand<Monitor>>();
        this.rootContainer.RegisterType<DeleteBaseCommand<MonitorDto, Monitor>>();
        this.rootContainer.RegisterType<InsertBaseCommand<Monitor>>();
        this.rootContainer.RegisterType<ShowInsertPageBaseCommand<Monitor>>();
        this.rootContainer.RegisterType<ShowEditPageBaseCommand<Monitor>>();
        this.rootContainer.RegisterType<HideInsertPageBaseCommand<Monitor>>();
        this.rootContainer.RegisterType<HideEditPageBaseCommand<Monitor>>();

        this.rootContainer.RegisterInstance(
            RestService.For<IDefaultCrudServiceAsync<Monitor, Guid>>(
                $@"http://localhost:19328/api/crud/{nameof(Monitor)}"));


        this.rootContainer.RegisterType<MonitorActionExecutionDtoCommandFactory>();
        this.rootContainer.RegisterType<MonitorCommandFactory>();
        this.rootContainer.RegisterType<LoadBaseCommand<MonitorDto>>();
        this.rootContainer.RegisterType<LoadBaseCommand<MonitorActionExecutionDto>>();

        this.rootContainer.RegisterView<ShellWindow, ShellViewModel>();
        this.rootContainer.RegisterView<LogView, LogViewModel>();
        this.rootContainer.RegisterView<SimpleActionResultView, SimpleActionResultViewModel>();
        this.rootContainer.RegisterView<MonitorView, MonitorViewModel>();
        this.rootContainer.RegisterView<EditView, EditViewModel, IEditView<Monitor>>();
        this.rootContainer.RegisterView<InsertView, InsertViewModel, IInsertView<Monitor>>();

        this.AddRestServices();

        this.rootContainer.RegisterType<DashboardReadCommand>();

        this.rootContainer.Register<ILoadDependentsCommand<Monitor>, LoadMonitorDependentsCommand>();
        this.rootContainer.RegisterType<LoadTargetsCommand>();
        this.rootContainer.RegisterType<LoadParameterCommand>();
        this.rootContainer.RegisterType<LoadActionsCommand>();
    }

    private void AddRestServices()
    {
        var targetTypDtoService =
            RestService.For<IDefaultReadServiceAsync<TargetTyp, Guid>>(
                $@"http://localhost:19328/api/read/{nameof(TargetTyp)}");
        var parameterTypDtoService =
            RestService.For<IDefaultReadServiceAsync<ParameterTyp, Guid>>(
                $@"http://localhost:19328/api/read/{nameof(ParameterTyp)}");
        var monitorDtoService =
            RestService.For<IDefaultReadServiceAsync<MonitorDto, Guid>>(
                $@"http://localhost:19328/api/read/{nameof(MonitorDto)}");
        var targetService =
            RestService.For<IDefaultReadServiceAsync<Target, Guid>>(
                $@"http://localhost:19328/api/crud/{nameof(Target)}");
        var parameterService =
            RestService.For<IDefaultReadServiceAsync<Parameter, Guid>>(
                $@"http://localhost:19328/api/crud/{nameof(Parameter)}");
        var actionService =
            RestService.For<IDefaultReadServiceAsync<Action, Guid>>(
                $@"http://localhost:19328/api/crud/{nameof(Action)}");
        var dashboardDtoService =
            RestService.For<IDashboardReadServiceAsync>($@"http://localhost:19328/api/read/{nameof(DashboardDto)}");
        var monitorActionExecutionDtoService =
            RestService.For<IDefaultReadServiceAsync<MonitorActionExecutionDto, Guid>>(
                $@"http://localhost:19328/api/read/{nameof(MonitorActionExecutionDto)}");

        this.rootContainer.RegisterInstance(targetTypDtoService);
        this.rootContainer.RegisterInstance(parameterTypDtoService);
        this.rootContainer.RegisterInstance(monitorDtoService);
        this.rootContainer.RegisterInstance(dashboardDtoService);
        this.rootContainer.RegisterInstance(monitorActionExecutionDtoService);
        this.rootContainer.RegisterInstance(targetService);
        this.rootContainer.RegisterInstance(parameterService);
        this.rootContainer.RegisterInstance(actionService);
    }

    //todo add project for every view
    //private static void AddDefaultCommands<T>(IContainer container) where T : class
    //{


    //todo entity framework target server and port to config file
    //todo add module structure pls for every project? or delete module and do all stuff here :)
    //}


    public static void StartApp(Window shell)
    {
        new Application().Run(shell);
    }

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public static void Main()
    {
        new Bootstrapper().Run();
    }
}