using AutoMapper;
using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Commands.Definitions.Branch.Create
{
    public class HandlerCreateBranch : IRequestHandler<RequestCreateBranch, ResponseCreateBranch>
    {
        readonly IBranchWriteRepository _branchWriteRepository;
        readonly IMapper _mapper;

        public HandlerCreateBranch(IMapper mapper, IBranchWriteRepository branchWriteRepository)
        {
            _mapper = mapper;
            _branchWriteRepository = branchWriteRepository;
        }

        public async Task<ResponseCreateBranch> Handle(RequestCreateBranch request, CancellationToken cancellationToken)
        {
            T.Branch branch = _mapper.Map<T.Branch>(request);
            await _branchWriteRepository.AddAsync(branch);
            await _branchWriteRepository.SaveAsync();

            return new();
        }
    }
}
