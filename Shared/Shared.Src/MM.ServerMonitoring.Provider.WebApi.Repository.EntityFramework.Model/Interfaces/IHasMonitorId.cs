namespace MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

public interface IHasMonitorId
{
    Guid MonitorId { get; }
}