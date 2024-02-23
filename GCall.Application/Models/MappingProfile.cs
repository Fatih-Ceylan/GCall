using AutoMapper;
using GCall.Application.Features.Queries.Definitions.Company.GetById;
using GCall.Application.Features.Queries.Definitions.Customer.GetById;
using GCall.Domain.Entities.Definitions;

namespace GCall.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile(string profileName) : base(profileName)
        {
            CreateMap<Company, ResponseGetByIdCompany>().ReverseMap();
            CreateMap<Customer, ResponseGetByIdCustomer>().ReverseMap();
        }
    }
}
