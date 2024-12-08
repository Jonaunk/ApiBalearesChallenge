using Domain.Common;
using Domain.Entities.Contactos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Domain
{
    public class Ciudad : AuditableBaseEntity
    {
        public string? Nombre { get; set; }
        public int? ProvinciaId { get; set; }

        public virtual Provincia? Provincia { get; set; }
        public virtual ICollection<Contacto>? Contactos { get; set; }
    }
}
