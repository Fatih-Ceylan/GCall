using MediatR;

namespace GCall.Application.Features.Queries.Definitions.Department.GetById
{
    public class RequestGetByIdDepartment : IRequest<ResponseGetByIdDepartment>
    {
        public string Id { get; set; }
    }
}
