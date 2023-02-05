using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;

/// <summary>
///     command collection object
/// </summary>
/// <typeparam name="TDto"></typeparam>
public class DefaultCommandFactory<TDto> : CrudCommandFactoryBase
    where TDto : IHasId
{
    public DefaultCommandFactory(
        LoadBaseCommand<TDto> readCommand,
        LoadSingleCommand<TDto> readSingleCommand,
        UpdateBaseCommand<TDto> updateCommand,
        DeleteBaseCommand<TDto, TDto> deleteByIdCommand,
        InsertBaseCommand<TDto> insertCommand,
        ShowInsertPageBaseCommand<TDto> showInsertPageCommand,
        ShowEditPageBaseCommand<TDto> showEditPageCommand,
        HideInsertPageBaseCommand<TDto> hideInsertPageCommand,
        HideEditPageBaseCommand<TDto> hideEditPageCommand,
        FilterBaseCommand<TDto> filterCommand
    ) : base(
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