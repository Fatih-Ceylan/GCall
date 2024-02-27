using AutoMapper;
using GCall.Application.DTOs.Definitions.Branch;
using GCall.Application.Features.Commands.Definitions.Branch.Create;
using GCall.Application.Features.Commands.Definitions.Branch.Update;
using GCall.Application.Features.Commands.Definitions.Company.Create;
using GCall.Application.Features.Commands.Definitions.Company.Update;
using GCall.Application.Features.Commands.Definitions.Department.Create;
using GCall.Application.Features.Queries.Definitions.Company.GetById;
using GCall.Application.Features.Queries.Definitions.Customer.GetById;
using GCall.Application.Features.Queries.Definitions.Department.GetById;
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

            #region Branch
            CreateMap<RequestCreateBranch, Branch>().ReverseMap();
            CreateMap<Branch, BranchFullDTO>().ReverseMap();
            CreateMap<RequestUpdateBranch, Branch>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember, destMember) =>
                {

                    return srcMember != null && !(srcMember is Guid guidValue && guidValue == Guid.Empty);
                });
            });

            CreateMap<Branch, ResponseUpdateBranch>();
            #endregion

            #region Department
            //CreateMap<Department, ResponseGetByIdDepartment>();
            CreateMap<RequestCreateDepartment, Department>().ReverseMap();
            #endregion

            #region Customer

            CreateMap<Customer, ResponseGetByIdCustomer>().ReverseMap();
            #endregion


        }
    }
}
