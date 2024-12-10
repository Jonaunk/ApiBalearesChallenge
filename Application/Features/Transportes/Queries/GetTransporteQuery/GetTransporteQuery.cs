using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transportes.Queries.GetTransporteQuery
{
    public class GetTransporteQuery : IRequest<Response<GetTransporteQueryResponse>>
    {
        public int Id { get; set; }
    }
}
