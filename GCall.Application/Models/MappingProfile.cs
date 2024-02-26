using AutoMapper;
using GCall.Application.Features.Commands.Definitions.Company.Create;
using GCall.Application.Features.Commands.Definitions.Company.Update;
using GCall.Application.Features.Queries.Definitions.Company.GetById;
using GCall.Application.Features.Queries.Definitions.Customer.GetById;
using GCall.Domain.Entities.Definitions;

namespace GCall.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Company
            CreateMap<Company, ResponseGetByIdCompany>();
            CreateMap<RequestCreateCompany, Company>();
            CreateMap<RequestUpdateCompany, Company>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Company, ResponseUpdateCompany>();
            #endregion

            #region Customer

            CreateMap<Customer, ResponseGetByIdCustomer>().ReverseMap();
            #endregion
        }
    }
}
