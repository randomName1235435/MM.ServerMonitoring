using Microsoft.EntityFrameworkCore;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

public static class DefaultMonitorConfiguration
{
    private static readonly Action<ModelBuilder> configuration = modelBuilder =>
    {
        modelBuilder.AddId<Monitor>();
        modelBuilder.AddForeignKey<Monitor>(
            item => item.ActionId,
            "ActionId");
        modelBuilder.AddForeignKey<Monitor>(
            item => item.TargetId,
            "TargetId");
        modelBuilder.AddForeignKey<Monitor>(
            item => item.ParameterId,
            "ParameterId");
        modelBuilder.AddName<Monitor>();
        modelBuilder.AddDescription<Monitor>();
        modelBuilder.Entity<Monitor>().HasOne(item => item.Action).WithMany();
        modelBuilder.Entity<Monitor>().HasOne(item => item.Target).WithMany();
        modelBuilder.Entity<Monitor>().HasOne(item => item.Parameter).WithMany();
    };

    public static Action<ModelBuilder> Get()
    {
        return configuration;
    }
}