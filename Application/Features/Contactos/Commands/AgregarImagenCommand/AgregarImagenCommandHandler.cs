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

namespace Application.Features.Contactos.Commands.AgregarImagenCommand
{
    public class AgregarImagenCommandHandler : IRequestHandler<AgregarImagenCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImagenService _imagenService;
        public AgregarImagenCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IImagenService imagenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imagenService = imagenService;
        }

        public async Task<Response<string>> Handle(AgregarImagenCommand request, CancellationToken cancellationToken)
        {
            var contacto = await _unitOfWork.Repository<Contacto>().GetByIdAsync(request.Id);

            if (contacto is null) throw new ApiException($"Contacto con ID {request.Id} no encontrado.");

           
            var base64Imagen = await _imagenService.ConvertirImagenABase64(request.Imagen);

            if (base64Imagen is null) throw new ApiException("No se pudo procesar la imagen");

            contacto.ImagenPerfil = base64Imagen;

            await _unitOfWork.Repository<Contacto>().UpdateAsync(contacto);
            await _unitOfWork.Repository<Contacto>().SaveChangesAsync(cancellationToken);

            return new Response<string>(true, "Imagen agregada exitosamente.");
        }
    }
}
