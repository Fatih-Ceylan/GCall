using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Customer.GetAll
{
    public class RequestGetAllCustomer :IRequest<ResponseGetAllCustomer>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
