using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Company.Delete
{
    public class RequestDeleteCompany : IRequest<ResponseDeleteCompany>
    {
        public string Id { get; set; }
    }
}
