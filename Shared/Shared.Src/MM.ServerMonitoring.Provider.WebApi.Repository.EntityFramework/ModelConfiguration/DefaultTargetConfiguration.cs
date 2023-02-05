using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

public static class DefaultTargetConfiguration
{
    private static readonly Action<ModelBuilder> configuration = modelBuilder =>
    {
        modelBuilder.AddId<Target>();
        modelBuilder.AddName<Target>();
        modelBuilder.AddForeignKey<Target>(
            item => item.TargetTypId,
            "TargetTypId");
        modelBuilder.Entity<Target>().HasOne(item => item.TargetTyp).WithMany();
    };

    public static Action<ModelBuilder> Get()
    {
        return configuration;
    }
}