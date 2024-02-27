using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Department.Update
{
    public class RequestUpdateDepartment: IRequest<ResponseUpdateDepartment>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? MainDepartmentId { get; set; }

    }
}
