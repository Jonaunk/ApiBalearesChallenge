using Application.Common.Wrappers;
using Application.Features.Authenticate.User;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<Response<string>> RegisterAsync(RegisterRequest request);
        Task<Response<AuthenticationResponse>> GetUser();
        Task<List<Usuario>> GetUsuariosOrdenadosPorEmailAsync();
    }
}
    