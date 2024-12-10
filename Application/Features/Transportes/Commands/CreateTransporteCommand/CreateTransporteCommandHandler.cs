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

namespace Application.Features.Transportes.Commands.CreateTransporteCommand
{
    public class CreateTransporteCommandHandler : IRequestHandler<CreateTransporteCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTransporteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateTransporteCommand request, CancellationToken cancellationToken)
        {

            var newTransporte = _mapper.Map<Transporte>(request);


            var transporte = await _unitOfWork.Repository<Transporte>().AddAsync(newTransporte);

            await _unitOfWork.Save(cancellationToken);

            return new Response<string>($"Se ha creado el transporte con Id:{transporte.Id}");


        }
    }
}
