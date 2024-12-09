using Application.Common.Exceptions;
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

namespace Application.Features.Contactos.Commands.UpdateContacto
{
    public class UpdateContactoCommandHandler : IRequestHandler<UpdateContactoCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateContactoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateContactoCommand request, CancellationToken cancellationToken)
        {
            var contacto = await _unitOfWork.Repository<Contacto>().GetByIdAsync(request.Id);

            if (contacto is null) throw new ApiException($"Contacto con ID {request.Id} no encontrado.");
        
            if(contacto.FechaBaja is not null) throw new ApiException($"Contacto con ID {request.Id} se encuentra dado de baja.");


            _mapper.Map(request, contacto);


            await _unitOfWork.Repository<Contacto>().UpdateAsync(contacto);
            await _unitOfWork.Repository<Contacto>().SaveChangesAsync(cancellationToken);

            return new Response<string>(true, $"Contacto con ID {request.Id} actualizado correctamente.");
        }
    }
}
