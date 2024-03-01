using GCall.Application.Features.Commands.Identity.AppUser.Login;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GCall.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class AuthController : ControllerBase
    {
        IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(RequestLoginAppUser request)
        {
            ResponseLoginAppUser response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
