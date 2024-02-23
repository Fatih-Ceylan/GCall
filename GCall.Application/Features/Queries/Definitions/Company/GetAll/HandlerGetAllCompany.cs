using GCall.Application.Features.Queries.Definitions.Customer.GetAll;
using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var totalCount = _companyReadRepository.GetAll(false).Count();
            var companies = _companyReadRepository.GetAll(false)
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
