using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Commands.Definitions.Department.Delete
{
    public class RequestDeleteDepartment : IRequest<ResponseDeleteDepartment>
    {
        public string Id { get; set; }

    }
}
