using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;

namespace GCall.Application.Features.Queries.Definitions.Customer.GetAll
{
    public class HandlerGetAllCustomer : IRequestHandler<RequestGetAllCustomer, ResponseGetAllCustomer>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public HandlerGetAllCustomer(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public Task<ResponseGetAllCustomer> Handle(RequestGetAllCustomer request, CancellationToken cancellationToken)
        {
            var totalCount = _customerReadRepository.GetAll(false).Count();
            var customers = _customerReadRepository.GetAll(false)
                                             .Skip(request.Page * request.Size)
                                             .Take(request.Size).ToList();

            return Task.FromResult(new ResponseGetAllCustomer
            {
                TotalCount = totalCount,
                Customers = customers,
            });
        }
    }
}
