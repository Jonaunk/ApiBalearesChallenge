using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries.GetUsuariosOrdenadosQuery
{
    public class GetUsuarioOrdenadosQueryHandler : IRequestHandler<GetUsuariosOrdenadosQuery, Response<List<GetUsuariosOrdenadosQueryResponse>>>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public GetUsuarioOrdenadosQueryHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetUsuariosOrdenadosQueryResponse>>> Handle(GetUsuariosOrdenadosQuery request, CancellationToken cancellationToken)
        {

            var usuarios = await _accountService.GetUsuariosOrdenadosPorEmailAsync();

            var response = _mapper.Map<List<GetUsuariosOrdenadosQueryResponse>>(usuarios);

            return new Response<List<GetUsuariosOrdenadosQueryResponse>>(response);

        }
    }
}
