using GCall.Application.DTOs.Identity;

namespace GCall.Application.Features.Commands.Identity.AppUser.Login
{
    public class ResponseLoginAppUser
    {
        public TokenDTO Token { get; set; }
        public string Message { get; set; } = "Authentication Succeed";
    }
}
