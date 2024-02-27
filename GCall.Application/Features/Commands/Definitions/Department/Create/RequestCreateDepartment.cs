using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Department.Create
{
    public class RequestCreateDepartment : IRequest<ResponseCreateDepartment>
    {
        public string Name { get; set; }
        public string? MainDepartmentId { get; set; }
    }
}
