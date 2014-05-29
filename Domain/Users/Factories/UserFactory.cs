using Domain.AbstractRepositories;
using Utilities.Transactions;

namespace Domain.Users.Factories
{
    public class UserFactory: IUserFactory
    {
        private readonly IUserRepository _userRepository;

        public UserFactory(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string name, string username, string email)
        {
            var user = new User(username, name, email, _userRepository);

            _userRepository.Create(user);



            return null;
        }
    }
}
