using System.Web.Http;
using Infrastructure.Services;
using Web.ViewModels.Login;

namespace Web.Controllers
{
    public class LoginApiController : ApiController
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public LoginApiController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        public object Login([FromBody]LoginViewModel viewModel)
        {
            var userLoginRequest = new UserLoginRequest
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
    }
}
