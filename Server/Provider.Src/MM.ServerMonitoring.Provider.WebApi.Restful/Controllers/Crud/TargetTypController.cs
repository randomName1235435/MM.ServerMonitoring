using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Crud;

[ApiController]
[Route("api/crud/[controller]")]
public class TargetTypController : DefaultBehaviorControllerBase<TargetTyp, WebApi.Dto.Model.Crud.TargetTyp>
{
    public TargetTypController(
        ICommandFactory<TargetTyp> commandFactory,
        IMapper<TargetTyp, WebApi.Dto.Model.Crud.TargetTyp> mapper,
        ILogger<DefaultBehaviorControllerBase<TargetTyp, WebApi.Dto.Model.Crud.TargetTyp>> logger) : base(
        commandFactory,
        mapper, logger)
    {
    }
}