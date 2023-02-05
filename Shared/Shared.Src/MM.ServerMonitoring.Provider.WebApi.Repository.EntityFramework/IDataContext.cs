using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Repository.EntityFramework;

public interface IDataContext : IDisposable
{
    public DbSet<Parameter> Parameter { get; }
    public DbSet<ParameterTyp> ParameterTyp { get; }
    public DbSet<Target> Target { get; }
    public DbSet<TargetTyp> TargetTyp { get; }
    public DbSet<Action> Action { get; }
    public DbSet<Monitor> Monitor { get; }
    public DbSet<MonitorActionExecution> MonitorActionExecution { get; }
    IDbContextTransaction BeginTransaction();
    DbSet<TEntity> Set<TEntity>() where TEntity : class, IHasId;
    void SaveChanges();
}