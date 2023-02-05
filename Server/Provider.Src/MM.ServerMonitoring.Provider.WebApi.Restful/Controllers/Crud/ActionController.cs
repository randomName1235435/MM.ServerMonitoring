using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Crud;

[ApiController]
[Route("api/crud/[controller]")]
public class ActionController : DefaultBehaviorControllerBase<Action, WebApi.Dto.Model.Crud.Action>
{
    public ActionController(
        ICommandFactory<Action> commandFactory,
        IMapper<Action, WebApi.Dto.Model.Crud.Action> mapper,
        ILogger<DefaultBehaviorControllerBase<Action, WebApi.Dto.Model.Crud.Action>> logger)
        : base(commandFactory, mapper, logger)
    {
    }
}