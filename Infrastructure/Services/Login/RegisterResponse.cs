using Infrastructure.Dto.User;

namespace Infrastructure.Services.Login
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public UserDto User { get; set; }
    }
}
