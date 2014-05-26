using System;
using System.Web.Http;
using Infrastructure.Services.Login;
using Infrastructure.Services.User;
using Web.ViewModels.Login;

namespace Web.Controllers
{
    [RoutePrefix("Login")]
    public class LoginApiController : ApiController
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;
        
        public LoginApiController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public object Login(LoginViewModel viewModel)
        {
            var userLoginRequest = new LoginRequest
            {
                Email = viewModel.Email,
                Password = viewModel.Password
            };

            var userLoginResponse = _loginService.Login(userLoginRequest);

            if (!userLoginResponse.Success)
            {
                return new
                {
                    LoginSuccessfull = false,
                    Message = userLoginResponse.ErrorMessage
                };
            }

            var userInfoRequest = new UserInfoRequest
            {
                Email = viewModel.Email
            };

            var userInfoResponse = _userService.Info(userInfoRequest);

            return new
            {
                LoginSuccessfull = true,
                User = userInfoResponse.User
            };
        }

        [HttpPost]
        [Route("Register")]
        public object Register(RegisterViewModel viewModel)
        {
            if (!viewModel.Password.Equals(viewModel.PasswordVerification, StringComparison.InvariantCulture))
            {
                return new {RegisterSuccessfull = false};
            }

            var registerRequest = new RegisterRequest
            {
                Username = viewModel.Username,
                Name = viewModel.Name,
                Email = viewModel.Email,
                Password = viewModel.Password
            };

            var registerResponse = _loginService.Register(registerRequest);
            return null;

        }
    }
}
