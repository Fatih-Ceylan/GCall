using GCall.Application.Features.Commands.Definitions.Customer.Create;
using GCall.Application.Features.Queries.Definitions.Customer.GetAll;
using GCall.Application.Features.Queries.Definitions.Customer.GetById;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GCall.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CustomerController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestGetAllCustomer requestGetAllCustomer)
        {
            ResponseGetAllCustomer response = await _mediator.Send(requestGetAllCustomer);

            _logger.Log(LogLevel.Trace, "Trace Loglama Başladı");
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] RequestGetByIdCustomer requestGetByIdCustomer)
        {
            ResponseGetByIdCustomer response = await _mediator.Send(requestGetByIdCustomer);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestCreateCustomer request)
        {
            ResponseCreateCustomer response = await _mediator.Send(request);

            //return Ok(response);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
