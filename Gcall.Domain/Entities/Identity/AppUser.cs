using Microsoft.AspNetCore.Identity;

namespace GCall.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
    }
}
