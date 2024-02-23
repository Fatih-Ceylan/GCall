using GCall.Application.Repositories.WriteRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Persistence.Repositories.WriteRepository.Definitions
{
    public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(GCallDbContext context) : base(context)
        {
        }
    }
}
