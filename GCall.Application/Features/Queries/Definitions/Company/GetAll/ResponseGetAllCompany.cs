using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Company.GetAll
{
    public class ResponseGetAllCompany
    {
        public int TotalCount { get; set; }

        public object Companies { get; set; }
    }
}
