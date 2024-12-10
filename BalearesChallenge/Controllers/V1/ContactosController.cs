using Application.Features.Authenticate.Commands.RegisterCommand;
using Application.Features.Contactos.Commands.AgregarImagenCommand;
using Application.Features.Contactos.Commands.CreateContacto;
using Application.Features.Contactos.Commands.DeleteContactoById;
using Application.Features.Contactos.Commands.UpdateContacto;
using Application.Features.Contactos.Queries.GetAllContactosQuery;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BalearesChallengeApi.Controllers.V1
{
    /// <summary>
    /// Controlador para gestionar el crud de contactos
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    public class ContactosController : BaseApiController
    {

        /// <summary>
        /// Crea un nuevo contacto.
        /// </summary>
        /// <param name="command">Informacion necesarioa para crear el contacto.</param>
        /// <returns>Si fue exitoso, devuelve el Id del nuevo contacto.</returns>
        [HttpPost]
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
                ProvinciaId = command.ProvinciaId,
                TransporteId = command.TransporteId
            }));
        }


        /// <summary>
        /// Devuelve una lista de contactos con la posibilidad de aplicar filtros por Id, Nombre, Email, Telefono, CiudadId, ProvinciaId. También permite ordenar los contactos por mail.
        /// </summary>
        /// <param name="filter">Parámetros de paginación y filtros para la búsqueda de contactos.</param>
        /// <returns>Lista de contactos según los criterios de búsqueda y paginación especificados.</returns>
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


        /// <summary>
        /// Elimina un contacto por su Id (Baja lógica).
        /// </summary>
        /// <param name="command">Contiene el Id del contacto a eliminar.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteContactoByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        /// <summary>
        /// Permite actualizar la información de un contacto existente.
        /// </summary>
        /// <param name="command">Contiene los datos a modificar</param>
        /// <returns>.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateContactoAsync(UpdateContactoCommand command)
        {
            return Ok(await Mediator.Send(new UpdateContactoCommand
            {
                Id = command.Id,
                Nombre = command.Nombre,
                Apellido = command.Apellido,
                Empresa = command.Empresa,
                Email = command.Email,
                FechaNacimiento = command.FechaNacimiento,
                Telefono = command.Telefono,
                Direccion = command.Direccion,
                CiudadId = command.CiudadId,
                ProvinciaId = command.ProvinciaId,
                TransporteId = command.TransporteId
            }));
        }


        /// <summary>
        /// Permite agregar una imagen a un contacto por su ID.
        /// </summary>
        /// <param name="command">Contiene el id del contacto y la imagen a agregar.</param>
        /// <returns></returns>
        [HttpPut("Imagen")]
        public async Task<IActionResult> AgregarImagenContactoAsync(AgregarImagenCommand command)
        {
            return Ok(await Mediator.Send(new AgregarImagenCommand { Id = command.Id, Imagen = command.Imagen }));
        }
    }
}
