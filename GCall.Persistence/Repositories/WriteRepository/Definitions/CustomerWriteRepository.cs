using GCall.Application.Repositories.WriteRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;

namespace GCall.Persistence.Repositories.WriteRepository.Definitions
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(GCallDbContext gCallDbContext) : base(gCallDbContext)
        {
        }
    }
}
