using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries.GetUsuariosOrdenadosQuery
{
    public class GetUsuariosOrdenadosQuery : IRequest<Response<List<GetUsuariosOrdenadosQueryResponse>>>
    {
        
    }
}
