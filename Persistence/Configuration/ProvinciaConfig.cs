using Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ProvinciaConfig : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.ToTable("Provincias");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(p => p.Ciudades)
                .WithOne(c => c.Provincia)
                .HasForeignKey(p => p.ProvinciaId);
        }
    }
}
