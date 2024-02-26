using GCall.Application.Features.Commands.Definitions.Branch.Create;
using GCall.Application.Features.Commands.Definitions.Company.Create;
using GCall.Application.Features.Queries.Definitions.Branch.GetAll;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GCall.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class BranchController : ControllerBase
    {
        readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestGetAllBranch requestGetAllBranch)
        {
            ResponseGetAllBranch response = await _mediator.Send(requestGetAllBranch);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestCreateBranch request)
        {
            ResponseCreateBranch response = await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
