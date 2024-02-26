using GCall.Application.Features.Queries.Definitions.Company.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Branch.GetAll
{
    public class RequestGetAllBranch : IRequest<ResponseGetAllBranch>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
