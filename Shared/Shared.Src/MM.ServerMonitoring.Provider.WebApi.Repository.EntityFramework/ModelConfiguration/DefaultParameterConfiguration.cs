using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Model;

namespace MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

public static class DefaultParameterConfiguration
{
    private static readonly Action<ModelBuilder> configuration = modelBuilder =>
    {
        modelBuilder.AddId<Parameter>();
        modelBuilder.AddForeignKey<Parameter>(
            item => item.ParameterTypId,
            "ParameterTypId");
        modelBuilder.Entity<Parameter>()
            .Property(item => item.Value)
            .HasColumnName("Value")
            .IsRequired()
            .HasColumnType("Vachar")
            .HasMaxLength(1000);
        modelBuilder.Entity<Parameter>().HasOne(item => item.ParameterTyp).WithMany();
    };

    public static Action<ModelBuilder> Get()
    {
        return configuration;
    }
}