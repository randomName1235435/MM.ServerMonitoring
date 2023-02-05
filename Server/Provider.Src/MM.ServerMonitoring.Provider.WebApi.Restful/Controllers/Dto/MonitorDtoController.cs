using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Dto;

[Route("api/read/[controller]")]
public class MonitorDtoController : ControllerDtoBase<MonitorDtoController>
{
    protected readonly IOneWayMapper<MonitorDto, Monitor> mapper;
    protected readonly IReadByIdWithIncludesCommand<Guid, Monitor> readByIdCommand;
    protected readonly IReadWithIncludesCommand<IEnumerable<Monitor>> readCommand;

    public MonitorDtoController(IReadWithIncludesCommand<IEnumerable<Monitor>> readCommand,
        IReadByIdWithIncludesCommand<Guid, Monitor> readByIdCommand,
        IOneWayMapper<MonitorDto, Monitor> mapper,
        ILogger<MonitorDtoController> logger) : base(logger)
    {
        _ = readCommand ?? throw new ArgumentNullException(nameof(readCommand));
        _ = readByIdCommand ?? throw new ArgumentNullException(nameof(readByIdCommand));
        _ = mapper ?? throw new ArgumentNullException(nameof(mapper));

        this.readCommand = readCommand;
        this.readByIdCommand = readByIdCommand;
        this.mapper = mapper;
    }

    [HttpGet]
    public virtual async Task<IEnumerable<MonitorDto>> Get(CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var resultCollection = await this.readCommand.ExecuteAsync(cancellationToken);
            var result = resultCollection.Select(item => this.mapper.Map(item));
            return result;
        });
    }

    [HttpGet("{id:guid}")]
    public virtual async Task<MonitorDto> Get(Guid id, CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var item = await this.readByIdCommand.ExecuteAsync(id, cancellationToken);
            var result = this.mapper.Map(item);
            return result;
        });
    }
}