using Domain.Entities.Contactos;
using Domain.Entities.Transportes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class TransporteConfig : IEntityTypeConfiguration<Transporte>
    {
        public void Configure(EntityTypeBuilder<Transporte> builder)
        {
            builder.ToTable("Transportes");

            builder.Property(p => p.Tipo)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(p => p.Contacto)
                .WithOne(c => c.Transporte)
                .HasForeignKey<Contacto>(c => c.TransporteId);



        }
    }
}
