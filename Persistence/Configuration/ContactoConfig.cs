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
    public class ContactoConfig : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.ToTable("Contactos");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Empresa)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.FechaNacimiento)
                .IsRequired();
                
            builder.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ImagenPerfil)
                 .HasColumnType("varchar(max)");

            builder.HasOne(p => p.Ciudad)
                .WithMany(c => c.Contactos)
                .HasForeignKey(c => c.CiudadId);

            builder.HasOne(p => p.Provincia)
                .WithMany(c => c.Contactos)
                .HasForeignKey(c => c.ProvinciaId);


            //builder.HasOne(p => p.Transporte)
            //    .WithOne(p => p.Contacto)
            //    .HasForeignKey<Transporte>(t => t.ContactoId);


        }
    }
}
