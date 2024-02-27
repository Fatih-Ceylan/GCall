using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Branch.Delete
{
    public class HandlerDeleteBranch : IRequestHandler<RequestDeleteBranch, ResponseDeleteBranch>
    {
        readonly IBranchWriteRepository _branchWriteRepository;

        public HandlerDeleteBranch(IBranchWriteRepository branchWriteRepository)
        {
            _branchWriteRepository = branchWriteRepository;
        }

        public async Task<ResponseDeleteBranch> Handle(RequestDeleteBranch request, CancellationToken cancellationToken)
        {
            await _branchWriteRepository.SoftDeleteAsync(request.Id);
            await _branchWriteRepository.SaveAsync();

            return new();
        }
    }
}
