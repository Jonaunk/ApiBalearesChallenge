using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Transportes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transportes.Queries.GetTransporteQuery
{
    public class GetTrasporteQueryHandler : IRequestHandler<GetTransporteQuery, Response<GetTransporteQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTrasporteQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<GetTransporteQueryResponse>> Handle(GetTransporteQuery request, CancellationToken cancellationToken)
        {
            var transporte = await _unitOfWork.Repository<Transporte>().GetByIdAsync(request.Id);

            var response = _mapper.Map<GetTransporteQueryResponse>(transporte);

            return new Response<GetTransporteQueryResponse>(response);
        }
    }
}
