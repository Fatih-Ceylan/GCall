using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Commands.Commands.Definitions.Create
{

    public class RequestCreateCustomer : IRequest<ResponseCreateCustomer>
    {
        public int Code { get; set; }
        public string Title { get; set; }
    }
}
