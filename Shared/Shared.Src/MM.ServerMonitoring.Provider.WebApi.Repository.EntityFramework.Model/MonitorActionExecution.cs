using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Model;

public class MonitorActionExecution : IHasId, IHasMonitorId, IHasTargetId, IHasActionId, IHasStartFinish
{
    public string Message { get; set; }
    public bool WasSuccess { get; set; }


    public Action Action { get; set; }
    public Target Target { get; set; }
    public Monitor Monitor { get; set; }
    public Guid ActionId { get; set; }
    public Guid Id { get; set; }
    public Guid MonitorId { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public Guid TargetId { get; set; }
}
//todo grpc from actionexecuter to webapi for sending data per signal r?