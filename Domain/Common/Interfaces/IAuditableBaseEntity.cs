using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Interfaces
{
    public interface IAuditableBaseEntity
    {
        string? UsuarioAlta { get; set; }
        DateTime FechaAlta { get; set; }
        string? UsuarioModificacion { get; set; }
        DateTime? FechaModificacion { get; set; }
        string? UsuarioBaja { get; set; }
        DateTime? FechaBaja { get; set; }
    }
}
