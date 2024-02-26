using GCall.Application.Repositories.WriteRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;

namespace GCall.Persistence.Repositories.WriteRepository.Definitions
{
    public class BranchWriteRepository : WriteRepository<Branch>, IBranchWriteRepository
    {
        public BranchWriteRepository(GCallDbContext context) : base(context)
        {
        }
    }
}
