using Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds
{
    public static class CiudadesSeed
    {


        public static async Task SeedCiudadAsync(ApplicationDbContext context)
        {
            var provincia = await context.Provincias.FirstOrDefaultAsync(x => x.Nombre == "Buenos Aires");

            if (!context.Ciudades.Any())
            {
                context.Ciudades.AddRange(new List<Ciudad>
        {
            new Ciudad
            {
                Nombre = "Berazategui",
                ProvinciaId = provincia!.Id
            },
            new Ciudad
            {
                Nombre = "La Plata",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "Mar del Plata",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "San Fernando",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "Lomas de Zamora",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "Lanús",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "Quilmes",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "Avellaneda",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "San Isidro",
                ProvinciaId = provincia.Id
            },
            new Ciudad
            {
                Nombre = "Tigre",
                ProvinciaId = provincia.Id
            }
        });

                await context.SaveChangesAsync();
            }
        }


    }
}
