using Domain.BaseObjects;
using Domain.Users;

namespace Domain.AbstractRepositories
{
    public interface IUserRepository: IRepository<User>
    {
        User Create(User user);
        bool EmailExists(string email);
    }
}
