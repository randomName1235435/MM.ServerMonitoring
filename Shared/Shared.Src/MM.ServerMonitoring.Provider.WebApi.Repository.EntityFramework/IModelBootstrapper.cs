using Microsoft.EntityFrameworkCore;

namespace MM.ServerMonitoring.Repository.EntityFramework;

public interface IModelBootstrapper
{
    void Setup(ModelBuilder modelBuilder);
}