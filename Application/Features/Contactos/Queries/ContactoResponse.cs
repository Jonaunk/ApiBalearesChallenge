using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Queries
{
    public class ContactoResponse
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public CiudadDTO? Ciudad { get; set; }
        public ProvinciaDTO? Provincia { get; set; }
        public string? ImagenPerfil { get; set; }
    }
}
