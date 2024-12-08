using Application.Features.Authenticate.Commands.RegisterCommand;
using Application.Features.Contactos.Commands.CreateContacto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalearesChallengeApi.Controllers.V1
{
    public class ContactosController : BaseApiController
    {


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateContactoAsync(CreateContactoCommand command)
        {
            return Ok(await Mediator.Send(new CreateContactoCommand
            {
                Nombre = command.Nombre,
                Apellido = command.Apellido,
                Email = command.Email,
                FechaNacimiento = command.FechaNacimiento,
                Telefono = command.Telefono,
                Direccion = command.Direccion,
                CiudadId = command.CiudadId
            }));
        }

    }
}
