using MediatR;

namespace GCall.Application.Features.Queries.Definitions.Branch.GetById
{
    public class RequestGetByIdBranch : IRequest<ResponseGetByIdBranch>
    {
        public string Id { get; set; }

    }
}
