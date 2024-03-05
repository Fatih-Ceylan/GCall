using GCall.Application.Absractions.Services;
using GCall.Application.DTOs.Identity;
using GCall.Application.DTOs.Identity.Auth.Login;
using MediatR;

namespace GCall.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin
{
    public class HandlerRefreshTokenLogin : IRequestHandler<RequestRefreshTokenLogin, ResponseRefreshTokenLogin>
    {
        readonly IAuthService _authService;

        public HandlerRefreshTokenLogin(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ResponseRefreshTokenLogin> Handle(RequestRefreshTokenLogin request, CancellationToken cancellationToken)
        {
            LoginResponseDTO loginResponseDto = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
            return new()
            {
                Token = loginResponseDto.Token,
            };
        }
    }
}
