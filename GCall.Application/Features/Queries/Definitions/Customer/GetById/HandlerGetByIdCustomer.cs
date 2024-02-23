using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Domain.Entities.Definitions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Queries.Definitions.Customer.GetById
{
    public class HandlerGetByIdCustomer : IRequestHandler<RequestGetByIdCustomer, ResponseGetByIdCustomer>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public HandlerGetByIdCustomer(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<ResponseGetByIdCustomer> Handle(RequestGetByIdCustomer request, CancellationToken cancellationToken)
        {
            T.Customer customer = await _customerReadRepository.GetByIdAsync(request.Id, false);
            return new ResponseGetByIdCustomer
            {
                Id = customer.Id,
                Code = customer.Code,
                Title = customer.Title
            };
        }
    }
}
