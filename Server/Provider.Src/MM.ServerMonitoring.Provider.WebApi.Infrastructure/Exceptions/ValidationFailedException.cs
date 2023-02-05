using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;

namespace MM.ServerMonitoring.Provider.WebApi.Infrastructure.Exceptions;

[Serializable]
public class ValidationFailedException : ServerMonitoringException
{
    public ValidationFailedException(ValidationResult result) : base(string.Join(Environment.NewLine,
        result.Messages.Select(message => message.Message)))
    {
    }
}