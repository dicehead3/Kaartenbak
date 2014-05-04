using Domain.BaseObjects;
using Domain.Users;

namespace Domain.AbstractRepositories
{
    public interface IUserRepository: IRepository<User>
    {
        void Create(User user, string password);
        bool EmailExists(string email);
        string GeneratePasswordResetHash(User user);
        bool IsPasswordResetHashValid(User user, string hash);
    }
}
