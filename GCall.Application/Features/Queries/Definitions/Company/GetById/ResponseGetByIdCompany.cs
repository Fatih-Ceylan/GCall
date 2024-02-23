using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Company.GetById
{
    public class ResponseGetByIdCompany
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
