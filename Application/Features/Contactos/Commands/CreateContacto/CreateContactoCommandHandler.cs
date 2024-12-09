using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Authenticate.Commands.AuthenticateCommand;
using Application.Features.Authenticate.User;
using AutoMapper;
using Domain.Entities.Contactos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Contactos.Commands.CreateContacto
{
    public class CreateContactoCommandHandler : IRequestHandler<CreateContactoCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateContactoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateContactoCommand command, CancellationToken cancellationToken)
        {
            var newContacto = _mapper.Map<Contacto>(command);

            await _unitOfWork.Repository<Contacto>().AddAsync(newContacto);

           

            await _unitOfWork.Save(cancellationToken);

            return new Response<string>(true, $"Se ha creado el contacto con Id: {newContacto.Id}");
        }
    }
}
