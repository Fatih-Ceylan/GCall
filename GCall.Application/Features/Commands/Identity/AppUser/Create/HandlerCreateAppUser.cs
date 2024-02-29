using T = GCall.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GCall.Application.Features.Commands.Identity.AppUser.Create
{
    public class HandlerCreateAppUser : IRequestHandler<RequestCreateAppUser, ResponseCreateAppUser>
    {
        readonly UserManager<T.AppUser> _userManager;

        public HandlerCreateAppUser(UserManager<T.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseCreateAppUser> Handle(RequestCreateAppUser request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
            }, request.Password);

            ResponseCreateAppUser response = new() { Succeed = result.Succeeded };
            if (!result.Succeeded)
            {
                response.Message = "";
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description} \n ";
                }
            }

            return response;
        }
    }
}
