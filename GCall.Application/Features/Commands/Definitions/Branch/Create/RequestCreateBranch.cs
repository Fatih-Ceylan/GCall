using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Branch.Create
{
    public class RequestCreateBranch : IRequest<ResponseCreateBranch>
    {
        public string CompanyId { get; set; }
        public string Name { get; set; }
    }
}
