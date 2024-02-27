using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Department.Delete
{
    public class HandlerDeleteDepartment : IRequestHandler<RequestDeleteDepartment, ResponseDeleteDepartment>
    {
        readonly IDepartmentWriteRepository _departmentWriteRepository;

        public HandlerDeleteDepartment(IDepartmentWriteRepository departmentWriteRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
        }

        public async Task<ResponseDeleteDepartment> Handle(RequestDeleteDepartment request, CancellationToken cancellationToken)
        {
            await _departmentWriteRepository.SoftDeleteAsync(request.Id);
            await _departmentWriteRepository.SaveAsync();

            return new();
        }
    }
}
