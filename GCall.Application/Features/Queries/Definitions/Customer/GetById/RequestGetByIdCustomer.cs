using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Customer.GetById
{
    public class RequestGetByIdCustomer : IRequest<ResponseGetByIdCustomer>
    {
        public string Id { get; set; }
    }
}
