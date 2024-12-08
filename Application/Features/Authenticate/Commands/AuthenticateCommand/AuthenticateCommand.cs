using Application.Common.Wrappers;
using Application.Features.Authenticate.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Commands.AuthenticateCommand
{
    public class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
