using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

public class MonitorActionExecutionDto : IHasId
{
    public TargetDto Target { get; set; }
    public ActionDto Action { get; set; }
    public ParameterDto Parameter { get; set; }
    public MonitorFlatDto Monitor { get; set; }
    public bool WasSuccess { get; set; }
    public string Message { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public Guid Id { get; init; }
}