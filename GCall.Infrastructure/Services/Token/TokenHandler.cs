using GCall.Application.Absractions.Token;
using GCall.Application.DTOs.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GCall.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDTO CreateAccessToken(int second)
        {
            TokenDTO tokenDTO = new TokenDTO();

            //Security Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentiales = new(securityKey, SecurityAlgorithms.HmacSha256);

            //oluşturulacak token ayarlarını veriyoruz.
            var audiences = _configuration.GetSection("Token:Audience").Get<string[]>();

            List<Claim> audienceClaims = new();
            foreach (var audience in audiences)
            {
                audienceClaims.Add(new Claim("aud", audience));
            }

            tokenDTO.ExpiryDate = DateTime.UtcNow.AddMinutes(second);
            JwtSecurityToken securityToken = new(
                issuer: _configuration["Token:Issuer"],
                expires: tokenDTO.ExpiryDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentiales,
                claims: audienceClaims
                );


            //Token oluşturucu sınıfından bir örnek alınacak.
            JwtSecurityTokenHandler tokenHandler = new();
            tokenDTO.AccessToken = tokenHandler.WriteToken(securityToken);

            tokenDTO.RefreshToken = CreateRefreshToken();
            return tokenDTO;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);

            return Convert.ToBase64String(number);
        }
    }
}
