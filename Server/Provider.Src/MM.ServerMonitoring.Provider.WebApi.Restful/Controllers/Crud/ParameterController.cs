using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Crud;

[ApiController]
[Route("api/crud/[controller]")]
public class ParameterController : DefaultBehaviorControllerBase<Parameter, WebApi.Dto.Model.Crud.Parameter>
{
    public ParameterController(
        ICommandFactory<Parameter> commandFactory,
        IMapper<Parameter, WebApi.Dto.Model.Crud.Parameter> mapper,
        ILogger<DefaultBehaviorControllerBase<Parameter, WebApi.Dto.Model.Crud.Parameter>> logger) : base(
        commandFactory,
        mapper, logger)
    {
    }
}