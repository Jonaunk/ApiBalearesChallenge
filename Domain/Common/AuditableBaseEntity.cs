using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class AuditableBaseEntity
    {
    }
    public abstract class AuditableBaseEntity<T> : BaseEntity<T>, IAuditableBaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string? UsuarioAlta { get; set; }
        [Required]
        public DateTime FechaAlta { get; set; }
        [MaxLength(50)]
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [MaxLength(50)]
        public string? UsuarioBaja { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
