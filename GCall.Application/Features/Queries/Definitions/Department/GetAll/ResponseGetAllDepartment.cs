using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Queries.Definitions.Department.GetAll
{
    public class ResponseGetAllDepartment
    {
        public int TotalCount { get; set; }
        public object Departments { get; set; }
    }
}
