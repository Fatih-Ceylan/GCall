using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;

namespace GCall.Persistence.Repositories.ReadRepository.Definitions
{
    public class BranchReadRepository : ReadRepository<Branch>, IBranchReadRepository
    {
        public BranchReadRepository(GCallDbContext context) : base(context)
        {
        }
    }
}
