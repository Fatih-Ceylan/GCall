using GCall.Application.Features.Commands.Identity.AppUser.Create;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GCall.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RequestCreateAppUser request)
        {
            ResponseCreateAppUser response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
