using MediatR;

namespace GCall.Application.Features.Commands.Identity.AppUser.Login
{
    public class RequestLoginAppUser : IRequest<ResponseLoginAppUser>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
