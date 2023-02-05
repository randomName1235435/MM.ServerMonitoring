using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

public static class DefaultParameterTypConfiguration
{
    private static readonly Action<ModelBuilder> configuration = modelBuilder =>
    {
        modelBuilder.AddId<ParameterTyp>();
        modelBuilder.AddName<ParameterTyp>();
        modelBuilder.AddDescription<ParameterTyp>();
    };

    public static Action<ModelBuilder> Get()
    {
        return configuration;
    }
}