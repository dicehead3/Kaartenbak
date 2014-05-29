using System;

namespace Domain.Users.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string name, string username, string email);
    }
}
