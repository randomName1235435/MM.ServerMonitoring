using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Crud;

[ApiController]
[Route("api/crud/[controller]")]
public class
    ParameterTypController : DefaultBehaviorControllerBase<ParameterTyp, WebApi.Dto.Model.Crud.ParameterTyp>
{
    public ParameterTypController(
        ICommandFactory<ParameterTyp> commandFactory,
        IMapper<ParameterTyp, WebApi.Dto.Model.Crud.ParameterTyp> mapper,
        ILogger<DefaultBehaviorControllerBase<ParameterTyp, WebApi.Dto.Model.Crud.ParameterTyp>> logger) :
        base(commandFactory,
            mapper, logger)
    {
    }
}