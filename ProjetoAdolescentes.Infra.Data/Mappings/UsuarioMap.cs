using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAdolescentes.Infra.Data.Contexts.Configuration;

namespace ProjetoAdolescentes.Infra.Data.Mappings;

public class UsuarioMap : CriticalBaseMap<Domain.Entities.Usuario>, IEntityTypeConfiguration<Domain.Entities.Usuario>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Usuario> entityBuilder)
    {
        base.Configure(entityBuilder);

        entityBuilder.AddSoftDeleteQueryFilter();

        entityBuilder.Property(x => x.Nome)
            .HasMaxLength(250);

        entityBuilder.Property(x => x.Username)
            .HasMaxLength(100);

        entityBuilder.Property(x => x.SenhaHash)
            .HasMaxLength(100);
    }
}
