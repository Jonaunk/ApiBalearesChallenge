using Domain.Entities.Domain;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds
{
    public static class ProvinciasSeed
    {
        public static async Task SeedProvinciaAsync(ApplicationDbContext context)
        {
            if (!context.Provincias.Any())
            {
                context.Provincias.AddRange(new List<Provincia>
                {
                    new Provincia
                    {
                        Nombre = "Buenos Aires"
                    },
                    new Provincia
                    {
                        Nombre = "Córdoba"
                    },
                    new Provincia
                    {
                        Nombre = "Santa Fe"
                    },
                    new Provincia
                    {
                        Nombre = "Mendoza"
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
