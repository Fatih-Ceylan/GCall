using AutoMapper;
using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Queries.Definitions.Department.GetById
{
    public class HandlerGetByIdDepartment : IRequestHandler<RequestGetByIdDepartment, ResponseGetByIdDepartment>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IMapper _mapper;

        public HandlerGetByIdDepartment(IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseGetByIdDepartment> Handle(RequestGetByIdDepartment request, CancellationToken cancellationToken)
        {
            T.Department departments = await _departmentReadRepository.GetByIdAsync(request.Id, false);

            return _mapper.Map<ResponseGetByIdDepartment>(departments);
        }
    }
}
