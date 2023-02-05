using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

public class MonitorActionExecution : IHasId
{
    public Guid ActionId { get; set; }
    public Guid MonitorId { get; set; }
    public Guid TargetId { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public string Message { get; set; }
    public bool WasSuccess { get; set; }
    public Guid Id { get; set; }
}
//todo grpc from actionexecuter to webapi for sending data per signal r?