namespace MM.ServerMonitoring.ActionExecutor.Model;

public class MonitorConfiguration
{
    public Guid MonitorId { get; set; }
    public string MonitorName { get; set; }
    public ActionConfiguration ActionConfiguration { get; set; }
    public TimeSpan Timeout { get; set; }
}