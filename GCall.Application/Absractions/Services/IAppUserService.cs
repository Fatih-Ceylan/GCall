using GCall.Application.DTOs.Identity.AppUser;
using GCall.Domain.Entities.Identity;

namespace GCall.Application.Absractions.Services
{
    public interface IAppUserService
    {
        Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
