using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Contactos;
using Domain.Entities.Transportes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transportes.Commands.UpdateTransporteCommand
{
    public class UpdateTransporteCommandHandler : IRequestHandler<UpdateTransporteCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTransporteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateTransporteCommand request, CancellationToken cancellationToken)
        {
            var transporte = await _unitOfWork.Repository<Transporte>().GetByIdAsync(request.Id);

            if (transporte is null)
            {
                return new Response<string>("Transporte no encontrado.");
            }

            _mapper.Map(request, transporte);


            await _unitOfWork.Repository<Transporte>().UpdateAsync(transporte);
            await _unitOfWork.Repository<Transporte>().SaveChangesAsync(cancellationToken);

            return new Response<string>(true, $"Transporte con ID {request.Id} actualizado correctamente.");

        }
    }
}
