namespace CarRentalSystem.Application.Features.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, string userId)
        {
            this.Token = token;
            this.UserId = userId;
        }

        public string UserId { get; }

        public string Token { get; }
    }
}
