using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BalearesChallengeApi.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
    }
}
