using GCall.Application.Repositories.WriteRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;

namespace GCall.Persistence.Repositories.WriteRepository.Definitions
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(GCallDbContext gCallDbContext) : base(gCallDbContext)
        {
        }
    }
}
