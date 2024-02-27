using AutoMapper;
using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Commands.Definitions.Department.Create
{
    public class HandlerCreateDepartment : IRequestHandler<RequestCreateDepartment, ResponseCreateDepartment>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IDepartmentWriteRepository _departmentWriteRepository;
        readonly IMapper _mapper;

        public HandlerCreateDepartment(IDepartmentReadRepository departmentReadRepository, IDepartmentWriteRepository departmentWriteRepository, IMapper mapper)
        {
            _departmentReadRepository = departmentReadRepository;
            _departmentWriteRepository = departmentWriteRepository;
            _mapper = mapper;
        }

        public async Task<ResponseCreateDepartment> Handle(RequestCreateDepartment request, CancellationToken cancellationToken)
        {
            T.Department departments = _mapper.Map<T.Department>(request);
            await _departmentWriteRepository.AddAsync(departments);
            await _departmentWriteRepository.SaveAsync();

            return new();
        }
    }
}
