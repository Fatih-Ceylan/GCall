using GCall.Application.DTOs.Identity;

namespace GCall.Application.Absractions.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
