using MediatR;

namespace GCall.Application.Features.Queries.Definitions.Company.GetById
{
    public class RequestGetByIdCompany : IRequest<ResponseGetByIdCompany>
    {
        public string Id { get; set; }
    }
}
