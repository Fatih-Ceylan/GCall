using GCall.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.Features.Commands.Commands.Definitions.Create
{
    public class HandlerCreateCustomer : IRequestHandler<RequestCreateCustomer, ResponseCreateCustomer>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;

        public HandlerCreateCustomer(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<ResponseCreateCustomer> Handle(RequestCreateCustomer request, CancellationToken cancellationToken)
        {
            await _customerWriteRepository.AddAsync(new()
            {
                Id = new Guid(),
                Code = request.Code,
                Title = request.Title,
            });
            await _customerWriteRepository.SaveAsync();

            return new();
        }
    }
}
