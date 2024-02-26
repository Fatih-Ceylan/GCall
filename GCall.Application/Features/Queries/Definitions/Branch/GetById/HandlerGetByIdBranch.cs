using AutoMapper;
using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Queries.Definitions.Branch.GetById
{
    public class HandlerGetByIdBranch : IRequestHandler<RequestGetByIdBranch, ResponseGetByIdBranch>
    {
        readonly IBranchReadRepository _branchReadRepository;
        readonly IMapper _mapper;

        public HandlerGetByIdBranch(IBranchReadRepository branchReadRepository, IMapper mapper)
        {
            _branchReadRepository = branchReadRepository;
            _mapper = mapper;
        }
        public async Task<ResponseGetByIdBranch> Handle(RequestGetByIdBranch request, CancellationToken cancellationToken)
        {
            T.Branch branch = await _branchReadRepository.GetByIdAsync(request.Id, false);
            return _mapper.Map<ResponseGetByIdBranch>(branch);
        }
    }
}
