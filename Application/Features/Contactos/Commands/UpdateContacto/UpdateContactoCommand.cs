using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Commands.UpdateContacto
{
    public class UpdateContactoCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Empresa { get; set; }

        public string? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int? CiudadId { get; set; }
        public int? ProvinciaId { get; set; }
        public int? TransporteId { get; set; }
    }
}
