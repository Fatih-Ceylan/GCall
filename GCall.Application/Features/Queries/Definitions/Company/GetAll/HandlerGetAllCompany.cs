
using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;

namespace GCall.Application.Features.Queries.Definitions.Company.GetAll
{
    public class HandlerGetAllCompany : IRequestHandler<RequestGetAllCompany, ResponseGetAllCompany>
    {
        readonly ICompanyReadRepository _companyReadRepository;

        public HandlerGetAllCompany(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }

        public Task<ResponseGetAllCompany> Handle(RequestGetAllCompany request, CancellationToken cancellationToken)
        {
            var totalCount = _companyReadRepository.GetAllDeletedStatus(false).Count();
            var companies = _companyReadRepository.GetAllDeletedStatusDescending(false)
                                             .Skip(request.Page * request.Size)
                                             .Take(request.Size).ToList();

            return Task.FromResult(new ResponseGetAllCompany
            {
                TotalCount = totalCount,
                Companies = companies,
            });
        }
    }
}
