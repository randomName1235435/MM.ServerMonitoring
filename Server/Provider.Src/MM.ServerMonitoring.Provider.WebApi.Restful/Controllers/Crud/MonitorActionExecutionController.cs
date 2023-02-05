using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Crud;

[ApiController]
[Route("api/crud/[controller]")]
public class MonitorActionExecutionController : DefaultBehaviorControllerBase<MonitorActionExecution,
    WebApi.Dto.Model.Crud.MonitorActionExecution>
{
    public MonitorActionExecutionController(
        ICommandFactory<MonitorActionExecution> commandFactory,
        IMapper<MonitorActionExecution, WebApi.Dto.Model.Crud.MonitorActionExecution> mapper,
        ILogger<DefaultBehaviorControllerBase<MonitorActionExecution, WebApi.Dto.Model.Crud.MonitorActionExecution>>
            logger) : base(commandFactory,
        mapper, logger)
    {
    }
}