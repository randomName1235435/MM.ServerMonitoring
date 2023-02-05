using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Command;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Insert;

public class InsertViewModel : MonitorEditInsertViewModelBase<InsertBaseCommand<Monitor>>, IInsertViewModel
{
    public InsertViewModel()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            TargetList = new ObservableCollection<IdNamePair>();
        else
            throw new Exception("only design time");
    }

    public InsertViewModel(IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        ILoadDependentsCommand<Monitor> loadDependentsCommand,
        InsertBaseCommand<Monitor> saveCommand
    ) : base(eventAggregator, dispatcher, loadDependentsCommand, saveCommand)
    {
        this.editItem = new Monitor { Id = Guid.NewGuid() };
        eventAggregator.GetEvent<InsertSucceedEvent<Monitor>>().Subscribe(this.SaveSucceed);
        eventAggregator.GetEvent<InsertFailedEvent<Monitor>>().Subscribe(this.SaveFailed);
    }
}