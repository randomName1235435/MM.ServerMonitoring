using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MM.ServerMonitoring.Repository.EntityFramework.Model;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;
using Action = MM.ServerMonitoring.Repository.EntityFramework.Model.Action;
using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;

namespace MM.ServerMonitoring.Repository.EntityFramework;

public class ServerMonitoringDataContext : DbContext, IDataContext, IDataContextAsync
{
    private readonly IModelBootstrapper modelBootstrapper;

    public ServerMonitoringDataContext(IModelBootstrapper modelBootstrapper)
    {
        this.modelBootstrapper = modelBootstrapper;
    }

    public DbSet<Parameter> Parameter { get; set; }
    public DbSet<ParameterTyp> ParameterTyp { get; set; }
    public DbSet<Target> Target { get; set; }
    public DbSet<TargetTyp> TargetTyp { get; set; }
    public DbSet<Action> Action { get; set; }
    public DbSet<Monitor> Monitor { get; set; }
    public DbSet<MonitorActionExecution> MonitorActionExecution { get; set; }

    public IDbContextTransaction BeginTransaction()
    {
        return Database.BeginTransaction();
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IHasId
    {
        return base.Set<TEntity>();
    }

    public new void SaveChanges()
    {
        base.SaveChanges();
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return Database.BeginTransactionAsync(cancellationToken);
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.modelBootstrapper.Setup(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost,1433;Database=MM.ServerMonitoring.Database;user id=apiUser;password=yourStrong(!)Password;MultipleActiveResultSets=true");
    }
}