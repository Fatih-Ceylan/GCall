using GCall.Application.DTOs.Identity.Auth.Login;

namespace GCall.Application.Absractions.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model);
    }
}
