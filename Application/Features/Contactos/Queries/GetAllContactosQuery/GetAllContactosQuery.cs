using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Queries.GetAllContactosQuery
{
    public class GetAllContactosQuery : PaginationContactosParameters, IRequest<PagedResponse<List<ContactoResponse>>>
    {
    }
}
