using Domain.Common;
using Domain.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contactos
{
    public class Contacto : AuditableBaseEntity
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Empresa { get; set; }
        public string? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int? CiudadId { get; set; }
        public int? ProvinciaId { get; set; }
        public string? ImagenPerfil { get; set; }

        public virtual Ciudad? Ciudad { get; set; }
        public virtual Provincia? Provincia { get; set; }
    }
}
