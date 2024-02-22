using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using GCall.Persistence.Contexts;

namespace GCall.Persistence.Repositories.ReadRepository.Definitions
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(GCallDbContext context) : base(context)
        {
        }
    }
}
