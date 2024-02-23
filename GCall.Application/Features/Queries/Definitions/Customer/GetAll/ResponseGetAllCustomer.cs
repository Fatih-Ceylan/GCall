using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Customer.GetAll
{
    public class ResponseGetAllCustomer
    {
        public int TotalCount { get; set; }

        public object Customers { get; set; }
    }
}
