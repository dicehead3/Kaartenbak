using Domain.AbstractRepositories;
using Domain.Users.Factories;

namespace Domain.Users.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserFactory _userFactory;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IUserFactory userFactory)
        {
            _authenticationRepository = authenticationRepository;
            _userFactory = userFactory;
        }

        public User RegisterUser(RegisterUserRequest request)
        {
            var user = _userFactory.CreateUser(request.Name, request.Username, request.Email);

            _authenticationRepository.SetPassword(user.Id, request.Password);

            return user;
        }
    }
}
