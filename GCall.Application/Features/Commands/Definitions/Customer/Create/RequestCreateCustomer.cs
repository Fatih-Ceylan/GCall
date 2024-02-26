using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Customer.Create
{

    public class RequestCreateCustomer : IRequest<ResponseCreateCustomer>
    {
        public int Code { get; set; }
        public string Title { get; set; }
    }
}
