using Microsoft.EntityFrameworkCore;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;

namespace MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

public static class DefaultActionConfiguration
{
    private static readonly Action<ModelBuilder> configuration = modelBuilder =>
    {
        modelBuilder.AddId<Action>();
        modelBuilder.AddName<Action>();
        modelBuilder.AddDescription<Action>();
    };

    public static Action<ModelBuilder> Get()
    {
        return configuration;
    }
}