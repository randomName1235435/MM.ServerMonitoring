namespace MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

public class DashboardDto
{
    public int CountMonitor { get; set; }
    public int CountResults { get; set; }
    public int CountActions { get; set; }
    public int CountFailed { get; set; }
    public int CountSuccess { get; set; }
    public int CountFailedLastHour { get; set; }
    public int Placeholder1 { get; set; }
    public int Placeholder2 { get; set; }
    public int Placeholder3 { get; set; }
    public int Placeholder4 { get; set; }
}