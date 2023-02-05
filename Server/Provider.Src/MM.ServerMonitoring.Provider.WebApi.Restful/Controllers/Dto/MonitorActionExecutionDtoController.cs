using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Dto;

[Route("api/read/[controller]")]
public class MonitorActionExecutionDtoController : ControllerDtoBase<MonitorActionExecutionDtoController>
{
    protected readonly IOneWayMapper<MonitorActionExecutionDto, MonitorActionExecution> mapper;
    protected readonly IReadByIdWithIncludesCommand<Guid, MonitorActionExecution> readByIdCommand;
    protected readonly IReadWithIncludesCommand<IEnumerable<MonitorActionExecution>> readCommand;

    public MonitorActionExecutionDtoController(
        IReadWithIncludesCommand<IEnumerable<MonitorActionExecution>> readCommand,
        IReadByIdWithIncludesCommand<Guid, MonitorActionExecution> readByIdCommand,
        IOneWayMapper<MonitorActionExecutionDto, MonitorActionExecution> mapper,
        ILogger<MonitorActionExecutionDtoController> logger) : base(logger)
    {
        _ = readCommand ?? throw new ArgumentNullException(nameof(readCommand));
        _ = readByIdCommand ?? throw new ArgumentNullException(nameof(readByIdCommand));
        _ = mapper ?? throw new ArgumentNullException(nameof(mapper));

        this.readCommand = readCommand;
        this.readByIdCommand = readByIdCommand;
        this.mapper = mapper;
    }

    [HttpGet]
    public virtual async Task<IEnumerable<MonitorActionExecutionDto>> Get(CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var resultCollection = await this.readCommand.ExecuteAsync(cancellationToken);
            var result = resultCollection.Select(item => this.mapper.Map(item));
            return result;
        });
    }

    [HttpGet("{id:guid}")]
    public virtual async Task<MonitorActionExecutionDto> Get(Guid id, CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var item = await this.readByIdCommand.ExecuteAsync(id, cancellationToken);
            var result = this.mapper.Map(item);
            return result;
        });
    }
}