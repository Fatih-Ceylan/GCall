using AutoMapper;
using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Commands.Definitions.Company.Update
{
    public class HandlerUpdateCompany : IRequestHandler<RequestUpdateCompany, ResponseUpdateCompany>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;

        public HandlerUpdateCompany(ICompanyWriteRepository companyWriteRepository, IMapper mapper, ICompanyReadRepository companyReadRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<ResponseUpdateCompany> Handle(RequestUpdateCompany request, CancellationToken cancellationToken)
        {
            T.Company company = await _companyReadRepository.GetByIdAsync(request.Id);
            company = _mapper.Map(request, company);
            await _companyWriteRepository.SaveAsync();

            return _mapper.Map<ResponseUpdateCompany>(company);
        }
    }
}
