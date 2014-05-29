using System;
using Domain.AbstractRepositories;
using Domain.Users;
using NHibernate;
using Utilities.ApplicationSettings;
using Utilities.Encryption;
using Utilities.Policies;

namespace Data.Repositories
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly IPasswordPolicy _passwordPolicy;
        private readonly IStaticApplicationSettings _staticApplicationSettings;
        private readonly ISession _session;
        private readonly IEncryptor _encryptor;

        public AuthenticationRepository(IPasswordPolicy passwordPolicy, IStaticApplicationSettings staticApplicationSettings, ISession session, IEncryptor encryptor)
        {
            _passwordPolicy = passwordPolicy;
            _staticApplicationSettings = staticApplicationSettings;
            _session = session;
            _encryptor = encryptor;
        }

        public void SetPassword(int id, string password)
        {
            if (!_passwordPolicy.Validate(password))
            {
                throw new ArgumentException("Password is not valid");
            }

            const string query = "UPDATE Users SET Password = :Password WHERE Id = :UserId";
            _session.CreateSQLQuery(query)
                .SetInt32("UserId", id)
                .SetString("Password", HashPassword(password))
                .UniqueResult();
        }

        public string GeneratePasswordResetHash(User user)
        {
            var hash = _encryptor.Encrypt(Guid.NewGuid().ToString());
            const string query = @"UPDATE Users
                                   SET ResetPasswordHash = :Hash,
                                       ResetPasswordExpireDateTime = :ExpireDateTime
                                   WHERE Id = :UserId";
            _session.CreateSQLQuery(query)
                .SetInt32("UserId", user.Id)
                .SetString("Hash", hash)
                .SetDateTime("ExpireDateTime", DateTime.UtcNow.Add(_staticApplicationSettings.PasswordResetExpirationPeriodInMinutes))
                .UniqueResult();

            return hash;
        }

        public bool IsPasswordResetHashValid(User user, string hash)
        {
            const string query = @"SELECT ResetPasswordHash
                                   FROM Users
                                   WHERE Id = :UserId
                                    and ResetPasswordExpireDateTime < :Now";
            var hashFromDatabase =
                _session.CreateSQLQuery(query)
                    .SetInt32("UserId", user.Id)
                    .SetDateTime("Now", DateTime.UtcNow)
                    .UniqueResult<string>();
            return hashFromDatabase != null && hashFromDatabase == hash;
        }

        public bool LoginUser(int userId, string password)
        {
            const string query = @"SELECT Password
                                    FROM Users
                                    WHERE Id = :UserId";
            var passwordFromDatabase =
                _session.CreateSQLQuery(query)
                    .SetInt32("UserId", userId)
                    .UniqueResult<string>();
            return IsPasswordEqual(password, passwordFromDatabase);
        }

        private string HashPassword(string password)
        {
            var random = new Random();
            var salt = String.Format("{0:x8}", random.Next(0x10000000));
            var pepper = String.Format("{0:x8}", random.Next(0x10000000));
            var passwordHash = salt + password + pepper;
            passwordHash = _encryptor.Encrypt(passwordHash);
            return salt + passwordHash + pepper;
        }

        private bool IsPasswordEqual(string password, string hashedPassword)
        {
            var salt = hashedPassword.Substring(0, 8);
            var pepper = hashedPassword.Substring(hashedPassword.Length - 8, 8);

            var passwordHash = salt + _encryptor.Encrypt(salt + password + pepper) + pepper;

            return hashedPassword == passwordHash;
        }
    }
}
