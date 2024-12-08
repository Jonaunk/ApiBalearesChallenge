using Domain.Entities.Contactos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Domain;

namespace Persistence.Configuration
{
    public class CiudadConfig : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("Ciudades");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(p => p.Provincia)
                .WithMany(c => c.Ciudades)
                .HasForeignKey(p => p.ProvinciaId);
        }
    }
}
