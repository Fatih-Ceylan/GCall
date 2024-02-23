using AutoMapper;
using GCall.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using T = GCall.Domain.Entities.Definitions;

namespace GCall.Application.Features.Queries.Definitions.Customer.GetById
{
    public class HandlerGetByIdCustomer : IRequestHandler<RequestGetByIdCustomer, ResponseGetByIdCustomer>
    {
        readonly ICustomerReadRepository _customerReadRepository;
        readonly IMapper _mapper;

        public HandlerGetByIdCustomer(ICustomerReadRepository customerReadRepository, IMapper mapper)
        {
            _customerReadRepository = customerReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseGetByIdCustomer> Handle(RequestGetByIdCustomer request, CancellationToken cancellationToken)
        {
            T.Customer customer = await _customerReadRepository.GetByIdAsync(request.Id, false);
            return _mapper.Map<ResponseGetByIdCustomer>(customer);
            //return new ResponseGetByIdCustomer
            //{
            //    Id = customer.Id,
            //    Code = customer.Code,
            //    Title = customer.Title
            //};
        }
    }
}
