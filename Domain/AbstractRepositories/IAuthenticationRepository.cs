using Domain.Users;

namespace Domain.AbstractRepositories
{
    public interface IAuthenticationRepository
    {
        void SetPassword(int id, string password);
        string GeneratePasswordResetHash(User user);
        bool IsPasswordResetHashValid(User user, string hash);
        bool LoginUser(int userId, string password);
    }
}
