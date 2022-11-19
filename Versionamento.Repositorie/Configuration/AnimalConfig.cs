using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versionamento.Domain.Entities;

namespace Versionamento.Data.Configuration
{
    public class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Nome).IsRequired();
        }
    }
}