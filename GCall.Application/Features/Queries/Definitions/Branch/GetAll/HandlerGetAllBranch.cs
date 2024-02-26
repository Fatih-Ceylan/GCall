using AutoMapper;
using GCall.Application.DTOs.Definitions.Branch;
using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using System.Linq.Expressions;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Queries.Definitions.Branch.GetAll
{
    public class HandlerGetAllBranch : IRequestHandler<RequestGetAllBranch, ResponseGetAllBranch>
    {
        readonly IBranchReadRepository _branchReadRepository;
        readonly IMapper _mapper;

        public HandlerGetAllBranch(IBranchReadRepository branchReadRepository, IMapper mapper)
        {
            _branchReadRepository = branchReadRepository;
            _mapper = mapper;
        }

        public Task<ResponseGetAllBranch> Handle(RequestGetAllBranch request, CancellationToken cancellationToken)
        {
            var totalCount = _branchReadRepository.GetAllDescending(false).Count();
            var branches = _branchReadRepository.GetAllIncluding(new Expression<Func<T.Branch, object>>[]
                {
                    x => x.Company
                }, false)
                         .Skip(request.Page * request.Size)
                         .Take(request.Size).ToList();

            // eski yöntem

            //var resultList = new List<GetAllBranchDTO>();
            //var result = new GetAllBranchDTO();

            //foreach (var branch in branches)
            //{
            //    result.CompanyName = branch.Company.Name;
            //    result.Name = branch.Name;
            //    result.CompanyId = branch.CompanyId;
            //    resultList.Add(result);
            //}


            return Task.FromResult(new ResponseGetAllBranch
            {
                TotalCount = totalCount,
                Branches = _mapper.Map<List<BranchListDTO>>(branches),
            });
        }
    }
}
