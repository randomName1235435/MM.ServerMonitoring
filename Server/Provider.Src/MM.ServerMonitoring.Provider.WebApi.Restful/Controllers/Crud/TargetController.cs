using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Crud;

[ApiController]
[Route("api/crud/[controller]")]
public class TargetController : DefaultBehaviorControllerBase<Target, WebApi.Dto.Model.Crud.Target>
{
    public TargetController(
        ICommandFactory<Target> commandFactory,
        IMapper<Target, WebApi.Dto.Model.Crud.Target> mapper,
        ILogger<DefaultBehaviorControllerBase<Target, WebApi.Dto.Model.Crud.Target>> logger) : base(
        commandFactory,
        mapper, logger)
    {
    }
}