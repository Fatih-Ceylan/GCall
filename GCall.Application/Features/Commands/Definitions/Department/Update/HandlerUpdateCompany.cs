using AutoMapper;
using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Commands.Definitions.Department.Update
{
    public class HandlerUpdateDepartment : IRequestHandler<RequestUpdateDepartment, ResponseUpdateDepartment>
    {
        readonly IMapper _mapper;
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IDepartmentWriteRepository _departmenthWriteRepository;

        public HandlerUpdateDepartment(IDepartmentWriteRepository departmenthWriteRepository, IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _departmenthWriteRepository = departmenthWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseUpdateDepartment> Handle(RequestUpdateDepartment request, CancellationToken cancellationToken)
        {
            T.Department departments = await _departmentReadRepository.GetByIdAsync(request.Id);
            departments = _mapper.Map(request, departments);
            await _departmenthWriteRepository.SaveAsync();

            return _mapper.Map<ResponseUpdateDepartment>(departments);
        }
    }
}
