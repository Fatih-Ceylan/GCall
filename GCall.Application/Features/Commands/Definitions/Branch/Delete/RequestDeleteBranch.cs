using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Commands.Definitions.Branch.Delete
{
    public class RequestDeleteBranch : IRequest<ResponseDeleteBranch>
    {
        public string Id { get; set; }
    }
}
