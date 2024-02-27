using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;

namespace GCall.Application.Features.Queries.Definitions.Department.GetAll
{
    public class HandlerGetAllDepartment : IRequestHandler<RequestGetAllDepartment, ResponseGetAllDepartment>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;

        public HandlerGetAllDepartment(IDepartmentReadRepository departmentReadRepository)
        {
            _departmentReadRepository = departmentReadRepository;
        }

        public Task<ResponseGetAllDepartment> Handle(RequestGetAllDepartment request, CancellationToken cancellationToken)
        {
            var totalCount = _departmentReadRepository.GetAllDeletedStatus(false).Count();
            var departments = _departmentReadRepository.GetAllDeletedStatusDescending(false)
                                             .Skip(request.Page * request.Size)
                                             .Take(request.Size).ToList();

            return Task.FromResult(new ResponseGetAllDepartment
            {
                TotalCount = totalCount,
                Departments = departments,
            });
        }
    }
}
