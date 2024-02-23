using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Persistence.Repositories.ReadRepository.Definitions
{
    public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(GCallDbContext context) : base(context)
        {
        }
    }
}
