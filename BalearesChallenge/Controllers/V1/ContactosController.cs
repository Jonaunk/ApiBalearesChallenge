using Application.Features.Authenticate.Commands.RegisterCommand;
using Application.Features.Contactos.Commands.CreateContacto;
using Application.Features.Contactos.Commands.DeleteContactoById;
using Application.Features.Contactos.Queries.GetAllContactosQuery;
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
                Empresa = command.Empresa,
                Email = command.Email,
                FechaNacimiento = command.FechaNacimiento,
                Telefono = command.Telefono,
                Direccion = command.Direccion,
                CiudadId = command.CiudadId,
                ProvinciaId = command.ProvinciaId
            }));
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationContactosParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllContactosQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Id = filter.Id,
                Nombre = filter.Nombre,
                Email = filter.Email,
                Telefono = filter.Telefono,
                CiudadId = filter.CiudadId,
                ProvinciaId = filter.ProvinciaId,
                OrdenarPorMail = filter.OrdenarPorMail
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteContactoByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
