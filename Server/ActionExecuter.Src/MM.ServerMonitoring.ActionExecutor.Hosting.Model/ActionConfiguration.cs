using System.Collections.Immutable;

namespace MM.ServerMonitoring.ActionExecutor.Model;

public class ActionConfiguration
{
    public Guid ActionId { get; set; }
    public string ActionName { get; set; }

    public IDictionary<string, string> ParameterCollection { get; init; }
        = ImmutableDictionary<string, string>.Empty;

    public TimeSpan Timeout { get; set; }
}


//public class WorkerConfigurationServiceFromEf : IWorkerConfigurationService