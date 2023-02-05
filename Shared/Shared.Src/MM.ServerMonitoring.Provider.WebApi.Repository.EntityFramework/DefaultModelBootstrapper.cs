using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

namespace MM.ServerMonitoring.Repository.EntityFramework;

public class DefaultModelBootstrapper : IModelBootstrapper
{
    public void Setup(ModelBuilder modelBuilder)
    {
        var configurationParameter = DefaultParameterConfiguration.Get();
        configurationParameter(modelBuilder);
        var configurationAction = DefaultActionConfiguration.Get();
        configurationAction(modelBuilder);
        var configurationMonitor = DefaultMonitorConfiguration.Get();
        configurationMonitor(modelBuilder);
        var configurationMonitorActionExecution = DefaultMonitorActionExecutionConfiguration.Get();
        configurationMonitorActionExecution(modelBuilder);
        var configurationTypParameter = DefaultParameterTypConfiguration.Get();
        configurationTypParameter(modelBuilder);
        var configurationTarget = DefaultTargetConfiguration.Get();
        configurationTarget(modelBuilder);
        var configurationTargetTyp = DefaultTargetTypConfiguration.Get();
        configurationTargetTyp(modelBuilder);
    }
}