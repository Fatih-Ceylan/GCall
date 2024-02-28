using GCall.Application.Features.Commands.Definitions.Branch.Create;
using GCall.Application.Features.Commands.Definitions.Branch.Delete;
using GCall.Application.Features.Commands.Definitions.Branch.Update;
using GCall.Application.Features.Queries.Definitions.Branch.GetAll;
using GCall.Application.Features.Queries.Definitions.Branch.GetById;
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
        public async Task<IActionResult> GetAllBranch([FromQuery] RequestGetAllBranch requestGetAllBranch)
        {
            ResponseGetAllBranch response = await _mediator.Send(requestGetAllBranch);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdBranch([FromRoute] RequestGetByIdBranch requestGetByIdBranch)
        {
            ResponseGetByIdBranch response = await _mediator.Send(requestGetByIdBranch);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] RequestCreateBranch request)
        {
            ResponseCreateBranch response = await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranch([FromBody] RequestUpdateBranch request)
        {
            ResponseUpdateBranch response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBranch([FromRoute] RequestDeleteBranch request)
        {
            ResponseDeleteBranch response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
