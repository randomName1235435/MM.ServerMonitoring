using Microsoft.AspNetCore.Mvc;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;
using MM.ServerMonitoring.Provider.WebApi.Interface;
using MM.ServerMonitoring.Provider.WebApi.Interface.Command;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;

namespace MM.ServerMonitoring.Provider.WebApi.Restful.Controllers.Dto;

[Route("api/read/[controller]")]
public class DashboardDtoController : ControllerDtoBase<DashboardDtoController>
{
    protected readonly IOneWayMapper<DashboardDto, Dashboard> mapper;
    protected readonly IReadCommand<Dashboard> readCommand;

    public DashboardDtoController(IReadCommand<Dashboard> readCommand,
        IOneWayMapper<DashboardDto, Dashboard> mapper,
        ILogger<DashboardDtoController> logger) : base(logger)
    {
        _ = readCommand ?? throw new ArgumentNullException(nameof(readCommand));
        _ = mapper ?? throw new ArgumentNullException(nameof(mapper));

        this.readCommand = readCommand;
        this.mapper = mapper;
    }

    [HttpGet]
    public virtual async Task<DashboardDto> Get(CancellationToken cancellationToken)
    {
        return await this.WithLogging(async () =>
        {
            var resultItem = await this.readCommand.ExecuteAsync(cancellationToken);
            var result = this.mapper.Map(resultItem);
            return result;
        });
    }
}