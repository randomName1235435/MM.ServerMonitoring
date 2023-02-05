namespace MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;

[Serializable]
public class ServerMonitoringException : Exception
{
    public ServerMonitoringException() : base(string.Empty)
    {
    }

    public ServerMonitoringException(string message) : base(message)
    {
    }

    public ServerMonitoringException(string message, Exception innerException) : base(message, innerException)
    {
    }
}