using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Commands.DeleteContactoById
{
    public class DeleteContactoByIdCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
