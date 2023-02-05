namespace MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;

public class HasDependenciesException : ServerMonitoringException
{
    public HasDependenciesException() : base(string.Empty)
    {
    }

    public HasDependenciesException(string message) : base(message)
    {
    }

    public HasDependenciesException(string message, Exception innerException) : base(message, innerException)
    {
    }
}