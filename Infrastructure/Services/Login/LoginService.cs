using Domain.Users.Services;

namespace Infrastructure.Services.Login
{
    public class LoginService: ILoginService
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public LoginResponse Login(LoginRequest request)
        {
            return new LoginResponse();
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            var registerUserRequest = new RegisterUserRequest()
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                Username = request.Username
            };

            var response = _authenticationService.RegisterUser(registerUserRequest);
            return new RegisterResponse {Success = true};
        }
    }
}
