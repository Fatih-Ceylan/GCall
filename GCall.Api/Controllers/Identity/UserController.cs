using GCall.Application.Features.Commands.Definitions.Company.Create;
using GCall.Application.Features.Commands.Identity.AppUser.Create;
using GCall.Application.Features.Commands.Identity.AppUser.Login;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(RequestLoginAppUser request)
        {
            ResponseLoginAppUser response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
