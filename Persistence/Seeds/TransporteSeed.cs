using Domain.Entities.Domain;
using Domain.Entities.Transportes;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds
{
    public static class TransporteSeed
    {
        public static async Task SeedTransporteAsync(ApplicationDbContext context)
        {
            if (!context.Transportes.Any())
            {
                context.Transportes.AddRange(new List<Transporte>
                {

                    new Transporte
                    {
                        Tipo = "Bicicleta"

                    },
                     new Transporte
                    {
                        Tipo = "Vehiculo"

                    },
                      new Transporte
                    {
                        Tipo = "Tren"

                    },
                       new Transporte
                    {
                        Tipo = "Avion"

                    }

                });
            }
        }

    }
}