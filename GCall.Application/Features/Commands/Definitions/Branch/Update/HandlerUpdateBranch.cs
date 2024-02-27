using AutoMapper;
using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Commands.Definitions.Branch.Update
{
    public class HandlerUpdateBranch : IRequestHandler<RequestUpdateBranch, ResponseUpdateBranch>
    {
        readonly IMapper _mapper;
        readonly IBranchReadRepository _branchReadRepository;
        readonly IBranchWriteRepository _branchWriteRepository;

        public HandlerUpdateBranch(IMapper mapper, IBranchReadRepository branchReadRepository, IBranchWriteRepository branchWriteRepository)
        {
            _mapper = mapper;
            _branchReadRepository = branchReadRepository;
            _branchWriteRepository = branchWriteRepository;
        }

        public async Task<ResponseUpdateBranch> Handle(RequestUpdateBranch request, CancellationToken cancellationToken)
        {
            T.Branch branches = await _branchReadRepository.GetByIdAsync(request.Id);
            branches = _mapper.Map(request, branches);
            await _branchWriteRepository.SaveAsync();

            return _mapper.Map<ResponseUpdateBranch>(branches);
        }
    }
}
