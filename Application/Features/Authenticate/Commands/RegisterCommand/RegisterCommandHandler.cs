using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Authenticate.User;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<string>>
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(IAccountService accountService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountService.RegisterAsync(new RegisterRequest
            {
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
            });
            return user;
        }
    }
}
