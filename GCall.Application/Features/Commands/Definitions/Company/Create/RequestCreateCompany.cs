using MediatR;

namespace GCall.Application.Features.Commands.Definitions.Company.Create
{
    public class RequestCreateCompany : IRequest<ResponseCreateCompany>
    {
        public string Name { get; set; }
        public string? WebAddress { get; set; }
        public string? TaxNo { get; set; }
        public string? TaxOffice { get; set; }
        public string? TradeRegisterNo { get; set; }
        public string? SocialSecurityNo { get; set; }
        public string? MersisNo { get; set; }
        public string? LogoPath { get; set; }
    }
}
