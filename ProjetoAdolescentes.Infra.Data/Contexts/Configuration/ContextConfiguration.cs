using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAdolescentes.Domain.Primitives;

namespace ProjetoAdolescentes.Infra.Data.Contexts.Configuration;

public static class ContextConfiguration
{
    internal static EntityTypeBuilder AddSoftDeleteQueryFilter<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T : EditableEntity
    {
        entityTypeBuilder.HasQueryFilter(c => EF.Property<DateTime?>(c, "ExcluidoEm") == null);
        return entityTypeBuilder;
    }

    internal static void SaveDefaultPropertiesChanges(ChangeTracker changeTracker)
    {
        UpdateDateProperties(changeTracker);
        EnableSoftDelete(changeTracker);
    }

    private static void UpdateDateProperties(ChangeTracker changeTracker)
    {
        foreach (var entry in changeTracker.Entries()
           .Where(e => e.State == EntityState.Added && e.Entity is EditableEntity))
        {
            entry.Property("CriadoEm").CurrentValue = DateTime.UtcNow;
        }

        foreach (var entry in changeTracker.Entries()
            .Where(e => e.State == EntityState.Modified && e.Entity is EditableEntity))
        {
            entry.Property("AtualizadoEm").CurrentValue = DateTime.UtcNow;
        }
    }

    private static void EnableSoftDelete(ChangeTracker changeTracker)
    {
        foreach (var entry in changeTracker.Entries()
           .Where(p => p.State == EntityState.Deleted && p.Entity is EditableEntity))
        {
            entry.Property("ExcluidoEm").CurrentValue = DateTime.UtcNow;
            entry.State = EntityState.Modified;
        }
    }
}