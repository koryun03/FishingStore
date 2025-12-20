using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Fishing.Core.Database;

public static class ModelBuilderExtensions
{
    public static void ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder)
    {
        var entityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(t =>
                typeof(ISoftDeletable).IsAssignableFrom(t.ClrType) &&
                (t.BaseType == null ||
                 !typeof(ISoftDeletable).IsAssignableFrom(t.BaseType.ClrType)));

        foreach (var entityType in entityTypes)
        {
            ApplyFilter(modelBuilder, entityType.ClrType);
        }
    }

    private static void ApplyFilter(ModelBuilder modelBuilder, Type clrType)
    {
        var method = typeof(ModelBuilderExtensions)
            .GetMethod(nameof(SetFilter), BindingFlags.NonPublic | BindingFlags.Static)!
            .MakeGenericMethod(clrType);

        method.Invoke(null, new object[] { modelBuilder });
    }

    private static void SetFilter<TEntity>(ModelBuilder modelBuilder)
        where TEntity : class, ISoftDeletable
    {
        modelBuilder.Entity<TEntity>()
            .HasQueryFilter(e => !e.IsDeleted);
    }
}