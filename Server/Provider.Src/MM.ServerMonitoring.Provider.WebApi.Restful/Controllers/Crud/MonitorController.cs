using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Crud;

[ApiController]
[Route("api/crud/[controller]")]
public class MonitorController : DefaultBehaviorControllerBase<Monitor, WebApi.Dto.Model.Crud.Monitor>
{
    public MonitorController(ICommandFactory<Monitor> commandFactory,
        IMapper<Monitor, WebApi.Dto.Model.Crud.Monitor> mapper,
        ILogger<DefaultBehaviorControllerBase<Monitor, WebApi.Dto.Model.Crud.Monitor>> logger) : base(commandFactory,
        mapper, logger)
    {
    }
}