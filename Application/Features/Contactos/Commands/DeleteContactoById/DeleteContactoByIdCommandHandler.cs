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

namespace Application.Features.Contactos.Commands.DeleteContactoById
{
    public class DeleteContactoByIdCommandHandler : IRequestHandler<DeleteContactoByIdCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteContactoByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<string>> Handle(DeleteContactoByIdCommand command, CancellationToken cancellationToken)
        {
            var contacto = await _unitOfWork.Repository<Contacto>().GetByIdAsync(command.Id);

            if (contacto is null)
            {
                return new Response<string>("Contacto no encontrado.");
            }

            await _unitOfWork.Repository<Contacto>().DeleteAsync(contacto);


            await _unitOfWork.Save(cancellationToken);

            return new Response<string>(true, "Eliminado exitosamente");
        }
    }
}
