using Application.Features.Authenticate.Commands.AuthenticateCommand;
using Application.Features.Authenticate.Commands.RegisterCommand;
using Application.Features.Authenticate.User;
using Microsoft.AspNetCore.Mvc;

namespace BalearesChallengeApi.Controllers.V1
{
    public class UsuariosController : BaseApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName
            }));
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            var result = await Mediator.Send(new AuthenticateCommand
            {
                Email = request.Email,
                Password = request.Password
            });
           
            return Ok(result);
        }
    }
}
