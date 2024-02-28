
using GCall.Application.Features.Commands.Definitions.Department.Create;
using GCall.Application.Features.Commands.Definitions.Department.Update;
using GCall.Application.Features.Queries.Definitions.Department.GetAll;
using GCall.Application.Features.Queries.Definitions.Department.GetById;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GCall.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class DepartmentController : ControllerBase
    {
        readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment([FromQuery] RequestGetAllDepartment requestGetAllDepartment)
        {
            ResponseGetAllDepartment response = await _mediator.Send(requestGetAllDepartment);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdDepartment([FromRoute] RequestGetByIdDepartment requestGetByIdDepartment)
        {
            ResponseGetByIdDepartment response = await _mediator.Send(requestGetByIdDepartment);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] RequestCreateDepartment request)
        {
            ResponseCreateDepartment response = await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] RequestUpdateDepartment request)
        {
            ResponseUpdateDepartment response = await _mediator.Send(request);

            return Ok(response);
        }

        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] RequestDeleteDepartment request)
        //{
        //    ResponseDeleteDepartment response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
