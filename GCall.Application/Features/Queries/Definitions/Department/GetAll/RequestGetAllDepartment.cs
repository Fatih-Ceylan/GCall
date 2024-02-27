using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Department.GetAll
{
    public class RequestGetAllDepartment : IRequest<ResponseGetAllDepartment>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
