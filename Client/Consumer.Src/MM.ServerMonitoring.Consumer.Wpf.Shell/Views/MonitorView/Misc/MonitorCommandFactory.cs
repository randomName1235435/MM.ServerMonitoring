using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Commands;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;

public class MonitorCommandFactory : CrudCommandFactoryBase
{
    //todo: maybe use separate interface for each command so u can mock them?
    public MonitorCommandFactory(
        LoadBaseCommand<MonitorDto> readCommand,
        LoadSingleCommand<MonitorDto> readSingleCommand,
        UpdateBaseCommand<Monitor> updateCommand,
        DeleteBaseCommand<MonitorDto, Monitor> deleteByIdCommand,
        InsertBaseCommand<Monitor> insertCommand,
        ShowInsertPageBaseCommand<Monitor> showInsertPageCommand,
        ShowEditPageBaseCommand<Monitor> showEditPageCommand,
        HideInsertPageBaseCommand<Monitor> hideInsertPageCommand,
        HideEditPageBaseCommand<Monitor> hideEditPageCommand,
        FilterMonitorCommand filterCommand) :
        base(
            readCommand,
            readSingleCommand,
            updateCommand,
            deleteByIdCommand,
            insertCommand,
            showInsertPageCommand,
            showEditPageCommand,
            hideInsertPageCommand,
            hideEditPageCommand,
            filterCommand)
    {
    }
}