using GCall.Application.Absractions.Services;
using GCall.Application.DTOs.Identity.Auth.Login;
using Microsoft.AspNetCore.Identity;
using T = GCall.Domain.Entities.Identity;
using GCall.Application.Absractions.Token;
using GCall.Application.DTOs.Identity;
using GCall.Application.Exceptions;
namespace GCall.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<T.AppUser> _userManager;
        readonly SignInManager<T.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(ITokenHandler tokenHandler, SignInManager<T.AppUser> signInManager, UserManager<T.AppUser> userManager)
        {
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model)
        {
            T.AppUser appUser = await _userManager.FindByNameAsync(model.UserNameOrEmail);
            if (appUser == null)
            {
                await _userManager.FindByEmailAsync(model.UserNameOrEmail);
            }
            if (appUser == null)
            {
                throw new NotFoundUserException();
            }
            //TODO: şifre kilitleme canlıya alınırken açılacak

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (result.Succeeded) // Authentication başarılı!
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(5);
                return new()
                {
                    Token = token
                };
            }
            throw new AuthenticationErrorException();
        }
    }
}
