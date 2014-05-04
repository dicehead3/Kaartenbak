using Domain.Users;

namespace Infrastructure.Services
{
    public class UserLoginResponse
    {
        public bool Success{ get; set; }
        public string ErrorMessage { get; set; }
    }
}