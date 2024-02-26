using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Commands.Definitions.Company.Delete
{
    public class RequestDeleteCompany : IRequest<ResponseDeleteCompany>
    {
        public string Id { get; set; }
    }
}
