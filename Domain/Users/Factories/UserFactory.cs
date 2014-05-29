using Domain.AbstractRepositories;

namespace Domain.Users.Factories
{
    public class UserFactory: IUserFactory
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationRepository _authenticationRepository;

        public UserFactory(IUserRepository userRepository, IAuthenticationRepository authenticationRepository)
        {
            _userRepository = userRepository;
            _authenticationRepository = authenticationRepository;
        }

        public User CreateUser(string name, string username, string email, string password)
        {
            var user = new User(username, name, email, _userRepository);

            var createdUser = _userRepository.Create(user);

            _authenticationRepository.SetPassword(createdUser.Id, password);

            return createdUser;
        }
    }
}
