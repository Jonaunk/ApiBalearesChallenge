using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transportes.Commands.CreateTransporteCommand
{
    public class CreateTransporteCommand : IRequest<Response<string>>
    {
        public string Tipo { get; set; }
    }
}
