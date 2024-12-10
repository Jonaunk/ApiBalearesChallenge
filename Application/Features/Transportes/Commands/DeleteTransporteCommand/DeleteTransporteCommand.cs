using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transportes.Commands.DeleteTransporteCommand
{
    public class DeleteTransporteCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }

}
