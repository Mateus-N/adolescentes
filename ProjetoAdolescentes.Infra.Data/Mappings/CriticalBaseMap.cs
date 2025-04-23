using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAdolescentes.Domain.Primitives;

namespace ProjetoAdolescentes.Infra.Data.Mappings;

public class CriticalBaseMap<T> : BaseMap<T> where T : CriticalEntity
{
    public void Configure(EntityTypeBuilder<T> entityBuilder)
    {
        base.Configure(entityBuilder);
        entityBuilder.Property(x => x.Guid).ValueGeneratedOnAdd();
        entityBuilder.HasIndex(e => e.Guid).IsUnique();
    }
}