using GCall.Application.DTOs.Identity.AppUser;

namespace GCall.Application.Absractions.Services
{
    public interface IAppUserService
    {
        Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model);
    }
}
