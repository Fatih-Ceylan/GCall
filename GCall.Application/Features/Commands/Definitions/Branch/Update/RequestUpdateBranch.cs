using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Branch.Update
{
    public class RequestUpdateBranch : IRequest<ResponseUpdateBranch>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
