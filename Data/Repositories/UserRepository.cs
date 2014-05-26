using System;
using System.Linq;
using Domain.AbstractRepositories;
using Domain.Users;
using NHibernate;
using NHibernate.Linq;
using Utilities.ApplicationSettings;
using Utilities.Encryption;
using Utilities.Policies;
using Utilities.Transactions;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ISession _session;
        private readonly IStaticApplicationSettings _staticApplicationSettings;
        private readonly IPasswordPolicy _passwordPolicy;
        private readonly IEncryptor _encryptor;

        public UserRepository(ISession session, IStaticApplicationSettings staticApplicationSettings, IPasswordPolicy passwordPolicy, IEncryptor encryptor)
        {
            _session = session;
            _staticApplicationSettings = staticApplicationSettings;
            _passwordPolicy = passwordPolicy;
            _encryptor = encryptor;
        }

        public override ISession Session
        {
            get { return _session; }
        }

        public override void Save(User user)
        {
            if (!user.ExistsInDatabase())
            {
                throw new InvalidOperationException("User is not yet created, can't save.");
            }

            base.Save(user);
        }

        public User Create(User user)
        {
            if (user.Id != 0)
            {
                throw new InvalidOperationException("User already exists");
            }

            using (var transaction = new Transaction(_session))
            {
                base.Save(user);
                transaction.Commit();
            }

            return user;
        }

        public bool EmailExists(string email)
        {
            return Session.Query<User>().Any(x => x.Email == email);
        }

       
    }
}