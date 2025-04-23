using Microsoft.EntityFrameworkCore;
using ProjetoAdolescentes.Domain.Entities;
using ProjetoAdolescentes.Infra.Data.Contexts.Configuration;

namespace ProjetoAdolescentes.Infra.Data.Contexts;

public class AdolescentesContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Usuario> Usuarios { get; set; }

    public async Task SaveChangesAsync()
    {
        ContextConfiguration.SaveDefaultPropertiesChanges(ChangeTracker);
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdolescentesContext).Assembly);
    }
}
