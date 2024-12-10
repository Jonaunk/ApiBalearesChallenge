using Domain.Common;
using Domain.Entities.Contactos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Transportes
{
    public class Transporte : AuditableBaseEntity
    {
        public string? Tipo { get; set; }

        //public int ContactoId { get; set; }

        public virtual Contacto? Contacto { get; set; }
    }
}
