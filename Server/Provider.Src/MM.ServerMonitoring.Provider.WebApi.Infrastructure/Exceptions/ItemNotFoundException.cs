namespace MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;

public class ItemNotFoundException : ServerMonitoringException
{
    public ItemNotFoundException() : base(string.Empty)
    {
    }

    public ItemNotFoundException(string message) : base(message)
    {
    }

    public ItemNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}