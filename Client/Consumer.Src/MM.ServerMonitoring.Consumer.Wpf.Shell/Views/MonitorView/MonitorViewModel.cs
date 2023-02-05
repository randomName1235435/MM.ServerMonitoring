using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.ViewModel;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView;

public class MonitorViewModel : CrudViewModelBase<Monitor, Monitor, Monitor, MonitorDto>
{
    public MonitorViewModel()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            Items = new ObservableCollection<MonitorDto>
            {
                new()
                {
                    Description = "lorem ipsum",
                    Id = Guid.NewGuid(),
                    Name = "test"
                }
            };
        else
            throw new Exception("only design time");
    }

    public MonitorViewModel(
        IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        MonitorCommandFactory commandFactory
    ) : base(eventAggregator, dispatcher, commandFactory)
    {
    }

    public override void ViewReady()
    {
        LoadCommand.Execute(null);
    }

    protected override void DeleteSucceed(Monitor deleted)
    {
        this.dispatcher.Invoke(() =>
            Items.Remove(Items.FirstOrDefault(item => item.Id == deleted.Id))
        );
    }
}