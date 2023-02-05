namespace MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;

public class InvalidStateException : ServerMonitoringException
{
    public InvalidStateException() : base(string.Empty)
    {
    }

    public InvalidStateException(string message) : base(message)
    {
    }

    public InvalidStateException(string message, Exception innerException) : base(message, innerException)
    {
    }
}