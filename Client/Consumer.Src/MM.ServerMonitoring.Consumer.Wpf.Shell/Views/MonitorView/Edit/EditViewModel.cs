using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Command;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using Prism.Events;
using Action = System.Action;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Edit;

public class EditViewModel : MonitorEditInsertViewModelBase<UpdateBaseCommand<Monitor>>, IEditViewModel
{
    private Action setDepends = () => { };

    //todo wenn null is also nix selectiert dann keine eingaben zulassen und button deaktivieren
    //todo wenn keine dependents geladen werden alle controls deaktivieren
    //event dazu einfangen () data failed und dann view disablen
    public EditViewModel()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        {
        }
        else
        {
            throw new Exception("only design time");
        }
    }

    public EditViewModel(IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        ILoadDependentsCommand<Monitor> loadDependentsCommand,
        UpdateBaseCommand<Monitor> saveCommand
    ) : base(eventAggregator, dispatcher, loadDependentsCommand, saveCommand)
    {
        eventAggregator.GetEvent<SelectedItemChanged<MonitorDto>>().Subscribe(this.SelectedItemChanged);
    }

    protected override void LoadDependentsSucceed(MonitorDependents obj)
    {
        base.LoadDependentsSucceed(obj);
        this.dispatcher.Invoke(() =>
        {
            this.setDepends = this.SetDependsMethod;
            this.setDepends();
        });
    }

    private static Monitor To(MonitorDto monitorDto)
    {
        return new Monitor
        {
            Id = monitorDto.Id,
            ActionId = monitorDto.Action.Id,
            Description = monitorDto.Description,
            Name = monitorDto.Name,
            ParameterId = monitorDto.Parameter.Id,
            TargetId = monitorDto.Target.Id
        };
    }

    private void SelectedItemChanged(MonitorDto obj)
    {
        EditItem = To(obj);
        this.setDepends();
    }

    private void SetDependsMethod()
    {
        SelectedAction = ActionList.FirstOrDefault(item => item.Id == EditItem?.ActionId);
        SelectedTarget = TargetList.FirstOrDefault(item => item.Id == EditItem?.TargetId);
        SelectedParameter = ParameterList.FirstOrDefault(item => item.Id == EditItem?.ParameterId);
    }
}