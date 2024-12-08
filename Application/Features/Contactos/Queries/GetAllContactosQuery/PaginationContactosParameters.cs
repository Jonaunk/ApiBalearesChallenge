using Application.Common.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Queries.GetAllContactosQuery
{
    public class PaginationContactosParameters : RequestParameters
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public int? CiudadId { get; set; }
        public int? ProvinciaId { get; set; }
    }
}
