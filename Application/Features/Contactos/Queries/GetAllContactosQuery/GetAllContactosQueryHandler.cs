using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Contactos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Queries.GetAllContactosQuery
{
    public class GetAllContactosQueryHandler : IRequestHandler<GetAllContactosQuery, PagedResponse<List<ContactoResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllContactosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<ContactoResponse>>> Handle(GetAllContactosQuery request, CancellationToken cancellationToken)
        {
            var listAllContactos = await _unitOfWork.Repository<Contacto>().ListAsync(new ContactoSpecification(request), cancellationToken);
            var totalRecords = await _unitOfWork.Repository<Contacto>().CountAsync(new ContactoSpecification(request), cancellationToken);
            var result = _mapper.Map<List<ContactoResponse>>(listAllContactos);

            return new PagedResponse<List<ContactoResponse>>(result, request.PageNumber, request.PageSize, totalRecords);
        }
    }
}
