using Application.Features.Contactos.Commands.CreateContacto;
using Application.Features.Contactos.Commands.DeleteContactoById;
using Application.Features.Contactos.Queries.GetAllContactosQuery;
using Application.Features.Transportes.Commands.CreateTransporteCommand;
using Application.Features.Transportes.Commands.DeleteTransporteCommand;
using Application.Features.Transportes.Commands.UpdateTransporteCommand;
using Application.Features.Transportes.Queries.GetTransporteQuery;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BalearesChallengeApi.Controllers.V1
{
    /// <summary>
    /// Controller para transporte
    /// </summary>
    [ApiVersion("1.0")]
    //[Authorize]
    public class TransportesController : BaseApiController
    {

        /// <summary>
        /// Endpoint para crear transporte
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTransporteAsync(CreateTransporteCommand command)
        {
            return Ok(await Mediator.Send(new CreateTransporteCommand
            {
                Tipo = command.Tipo
            }));
        }


        [HttpGet]
        public async Task<IActionResult> GetTransporteByIdAsync([FromQuery]GetTransporteQuery request)
        {
            return Ok(await Mediator.Send(new GetTransporteQuery
            {
                Id = request.Id
            }));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTransporteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTransporteAsync([FromBody] UpdateTransporteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
