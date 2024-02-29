using GCall.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using T = GCall.Domain.Entities.Identity;

namespace GCall.Application.Features.Commands.Identity.AppUser.Login
{
    public class HandlerLoginAppUser : IRequestHandler<RequestLoginAppUser, ResponseLoginAppUser>
    {
        readonly UserManager<T.AppUser> _userManager;
        readonly SignInManager<T.AppUser> _signInManager;

        public HandlerLoginAppUser(SignInManager<T.AppUser> signInManager, UserManager<T.AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ResponseLoginAppUser> Handle(RequestLoginAppUser request, CancellationToken cancellationToken)
        {
            T.AppUser appUser = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (appUser == null)
            {
                await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            }
            if (appUser == null)
            {
                throw new NotFoundUserException();
            }
            //TODO: şifre kilitleme canlıya alınırken açılacak
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);
            if (result.Succeeded) // Authentication başarılıysa
            {
                //TODO: yetkiler belirlenecek
            }

            return new();
        }
    }
}
