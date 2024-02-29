using AutoMapper;
using GCall.Application.DTOs.Definitions;
using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using System.Linq.Expressions;
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
            T.Branch branches = await _branchReadRepository.GetByIdAsyncIncluding(new Expression<Func<T.Branch, object>>[]
                {
                    x => x.Company
                }, request.Id, false);

            return await Task.FromResult(new ResponseGetByIdBranch
            {
                Branch = _mapper.Map<BranchFullDTO>(branches),
            });
        }
    }
}
