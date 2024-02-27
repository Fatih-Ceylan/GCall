using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;

namespace GCall.Persistence.Repositories.ReadRepository.Definitions
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(GCallDbContext context) : base(context)
        {
        }
    }
}
