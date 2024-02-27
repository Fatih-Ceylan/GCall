using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Company.Delete
{
    public class HandlerDeleteCompany : IRequestHandler<RequestDeleteCompany, ResponseDeleteCompany>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;

        public HandlerDeleteCompany(ICompanyWriteRepository companyWriteRepository)
        {
            _companyWriteRepository = companyWriteRepository;
        }

        public async Task<ResponseDeleteCompany> Handle(RequestDeleteCompany request, CancellationToken cancellationToken)
        {
            await _companyWriteRepository.SoftDeleteAsync(request.Id);
            await _companyWriteRepository.SaveAsync();

            return new();
        }
    }
}
