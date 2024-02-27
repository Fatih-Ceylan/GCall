namespace GCall.Application.Features.Commands.Definitions.Branch.Update
{
    public class ResponseUpdateBranch
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? CompanyId { get; set; }
        public string Message { get; set; } = "Update Branch Successful!";

    }
}
