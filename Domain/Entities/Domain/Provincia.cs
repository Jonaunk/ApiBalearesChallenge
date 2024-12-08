using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Domain
{
    public class Provincia : AuditableBaseEntity
    {
        public string? Nombre { get; set; }
        
        public virtual List<Ciudad>? Ciudades { get; set; }
    }
}
