using T = GCall.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using GCall.Application.Exceptions;

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
                Id = request.Id.ToString(),
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
            }, request.Password);

            if (result.Succeeded)
            {
                return new ResponseCreateAppUser
                {
                    Succeed = true
                };
            }
            throw new UserCreateFailedException(result.Errors.First().Description);

        }
    }
}
