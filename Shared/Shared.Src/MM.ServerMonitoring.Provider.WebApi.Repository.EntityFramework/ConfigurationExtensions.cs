using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework;

public static class ConfigurationExtensions
{
    public static ModelBuilder AddId<T>(this ModelBuilder modelBuilder)
        where T : class, IHasId
    {
        modelBuilder.Entity<T>()
            .Property(item => item.Id)
            .HasColumnName("Id")
            .HasColumnType("UniqueIdentifier");
        return modelBuilder;
    }

    public static ModelBuilder AddName<T>(this ModelBuilder modelBuilder)
        where T : class, IHasName
    {
        modelBuilder.Entity<T>()
            .Property(item => item.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(100);
        return modelBuilder;
    }

    public static ModelBuilder AddDescription<T>(this ModelBuilder modelBuilder)
        where T : class, IHasDescription
    {
        modelBuilder.Entity<T>()
            .Property(item => item.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(1000);
        return modelBuilder;
    }

    public static ModelBuilder AddForeignKey<T>(this ModelBuilder modelBuilder
        , Expression<Func<T, Guid>> propertyExpression, string columname)
        where T : class
    {
        modelBuilder.Entity<T>()
            .Property(propertyExpression)
            .HasColumnName(columname)
            .IsRequired()
            .HasColumnType("UniqueIdentifier");
        return modelBuilder;
    }

    public static ModelBuilder AddDateTime<T>(this ModelBuilder modelBuilder
        , Expression<Func<T, DateTime>> propertyExpression, string columname)
        where T : class
    {
        modelBuilder.Entity<T>()
            .Property(propertyExpression)
            .HasColumnName(columname)
            .IsRequired()
            .HasColumnType("DateTime");
        return modelBuilder;
    }

    public static ModelBuilder AddBool<T>(this ModelBuilder modelBuilder
        , Expression<Func<T, bool>> propertyExpression, string columname)
        where T : class
    {
        modelBuilder.Entity<T>()
            .Property(propertyExpression)
            .HasColumnName(columname)
            .IsRequired()
            .HasColumnType("Bit");
        return modelBuilder;
    }

    public static ModelBuilder AddStringLong<T>(this ModelBuilder modelBuilder
        , Expression<Func<T, string>> propertyExpression, string columname)
        where T : class
    {
        modelBuilder.Entity<T>()
            .Property(propertyExpression)
            .HasColumnName(columname)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(5000);
        return modelBuilder;
    }
}