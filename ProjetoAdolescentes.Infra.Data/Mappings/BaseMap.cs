using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoAdolescentes.Domain.Primitives;

namespace ProjetoAdolescentes.Infra.Data.Mappings;

public class BaseMap<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> entityBuilder)
    {
        entityBuilder.HasKey(e => e.Id);
        entityBuilder.Property(e => e.Id).ValueGeneratedOnAdd();
    }
}