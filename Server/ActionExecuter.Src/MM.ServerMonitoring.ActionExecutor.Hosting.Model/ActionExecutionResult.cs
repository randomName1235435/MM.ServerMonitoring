namespace MM.ServerMonitoring.ActionExecutor.Model;

public class ActionExecutionResult
{
    public ActionExecutionResult(bool success, DateTime start)
    {
        Success = success;
        Start = start;
        ResultText = success ? nameof(Success) : nameof(Failed);
    }

    public string ResultText { get; init; }
    public DateTime Start { get; init; }

    public bool Success { get; init; }
    public bool Failed => !Success;

    public Guid ActionId { get; set; }
    public Guid MonitorId { get; set; }

    public IEnumerable<string> Messages { get; init; }
    public string Target { get; set; }
}