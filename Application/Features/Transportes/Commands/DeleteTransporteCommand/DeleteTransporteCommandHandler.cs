using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Contactos.Commands.DeleteContactoById;
using AutoMapper;
using Domain.Entities.Contactos;
using Domain.Entities.Transportes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transportes.Commands.DeleteTransporteCommand
{
    public class DeleteTransporteCommandHandler : IRequestHandler<DeleteTransporteCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteTransporteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }


        public async Task<Response<string>> Handle(DeleteTransporteCommand command, CancellationToken cancellationToken)
        {
            var transporte = await _unitOfWork.Repository<Transporte>().GetByIdAsync(command.Id);

            if (transporte is null)
            {
                return new Response<string>("Transporte no encontrado.");
            }

            await _unitOfWork.Repository<Transporte>().DeleteAsync(transporte);


            await _unitOfWork.Save(cancellationToken);

            return new Response<string>(true, "Eliminado exitosamente");

        }
    }

}
