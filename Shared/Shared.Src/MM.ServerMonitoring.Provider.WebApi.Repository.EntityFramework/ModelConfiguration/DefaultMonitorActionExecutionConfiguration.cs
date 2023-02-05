using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Repository.EntityFramework.ModelConfiguration;

public static class DefaultMonitorActionExecutionConfiguration
{
    private static readonly Action<ModelBuilder> configuration = modelBuilder =>
    {
        modelBuilder.AddId<Monitor>();
        modelBuilder.AddForeignKey<MonitorActionExecution>(
            item => item.ActionId,
            "ActionId");
        modelBuilder.AddForeignKey<MonitorActionExecution>(
            item => item.MonitorId,
            "MonitorId");
        modelBuilder.AddForeignKey<MonitorActionExecution>(
            item => item.TargetId,
            "TargetId");
        modelBuilder.AddDateTime<MonitorActionExecution>(
            item => item.Start,
            "Start");
        modelBuilder.AddDateTime<MonitorActionExecution>(
            item => item.Finish,
            "Finish");
        modelBuilder.AddBool<MonitorActionExecution>(item => item.WasSuccess, "Success");
        modelBuilder.AddStringLong<MonitorActionExecution>(item => item.Message, "Message");
        modelBuilder.Entity<MonitorActionExecution>().HasOne(item => item.Monitor).WithMany();
        modelBuilder.Entity<MonitorActionExecution>().HasOne(item => item.Target).WithMany();
        modelBuilder.Entity<MonitorActionExecution>().HasOne(item => item.Action).WithMany();
    };

    public static Action<ModelBuilder> Get()
    {
        return configuration;
    }
}