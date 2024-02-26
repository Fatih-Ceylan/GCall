using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Company.GetById
{
    public class RequestGetByIdCompany : IRequest<ResponseGetByIdCompany>
    {
        public string Id { get; set; }
    }
}
