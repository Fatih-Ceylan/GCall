namespace GCall.Application.DTOs.Identity.Auth.Login
{
    public class LoginRequestDTO
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
