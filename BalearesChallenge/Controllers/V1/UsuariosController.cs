using Application.Features.Authenticate.Commands.AuthenticateCommand;
using Application.Features.Authenticate.Commands.RegisterCommand;
using Application.Features.Authenticate.User;
using Application.Features.Usuarios.Queries.GetUsuariosOrdenadosQuery;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalearesChallengeApi.Controllers.V1
{
    /// <summary>
    /// Controlador para gestion de usuarios del sistema
    /// </summary>
    
    [ApiVersion("1.0")]
    public class UsuariosController : BaseApiController
    {
        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="request">Los datos necesarios para el registro: nombre, apellido, email, contraseña y nombre de usuario.</param>
        /// <returns>Un resultado indicando si el registro fue exitoso o no. Si fue exitoso se devuelve el id.</returns>
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

        /// <summary>
        /// Autentica a un usuario y genera un token JWT.
        /// </summary>
        /// <param name="request">Los datos necesarios para la autenticación: email y contraseña.</param>
        /// <returns>Un token JWT si la autenticación es exitosa, junto con los detalles del usuario autenticado.</returns>
        /// 
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


        /// <summary>
        /// Obtiene una lista de usuarios ordenados por correo electrónico.
        /// </summary>
        /// <returns>Una lista de usuarios ordenada, incluyendo ID, nombre, apellido y email.</returns>
        [HttpGet("usuarios-ordenados")]
        [Authorize]
        public async Task<IActionResult> GetUsuariosOrdenadosAsync()
        {
            var result = await Mediator.Send(new GetUsuariosOrdenadosQuery());
            return Ok(result);
        }

    }
}
