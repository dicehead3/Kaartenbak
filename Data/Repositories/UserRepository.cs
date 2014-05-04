﻿using System;
using System.Linq;
using Domain.AbstractRepositories;
using Domain.Users;
using Infrastructure.ApplicationSettings;
using Infrastructure.Encryption;
using Infrastructure.Policies;
using NHibernate;
using NHibernate.Linq;

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

        public override void Save(User card)
        {
            if (!card.ExistsInDatabase())
            {
                throw new InvalidOperationException("User is not yet created, can't save.");
            }

            base.Save(card);
        }

        public void Create(User user, string password)
        {
            if (user.Id != 0)
            {
                throw new InvalidOperationException("User already exists");
            }

            if (!_passwordPolicy.Validate(password))
            {
                throw new ArgumentException("Password is not valid");
            }

            base.Save(user);

            const string query = "UPDATE Users SET Password = :Password WHERE Id = :UserId";
            Session.CreateSQLQuery(query)
                .SetInt32("UserId", user.Id)
                .SetString("Password", HashPassword(password))
                .UniqueResult();
        }

        public bool EmailExists(string email)
        {
            return Session.Query<User>().Any(x => x.Email == email);
        }

        public string GeneratePasswordResetHash(User user)
        {
            var hash = _encryptor.Encrypt(Guid.NewGuid().ToString());
            const string query = @"UPDATE Users
                                   SET ResetPasswordHash = :Hash,
                                       ResetPasswordExpireDateTime = :ExpireDateTime
                                   WHERE Id = :UserId";
            Session.CreateSQLQuery(query)
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
                Session.CreateSQLQuery(query)
                    .SetInt32("UserId", user.Id)
                    .SetDateTime("Now", DateTime.UtcNow)
                    .UniqueResult<string>();
            return hashFromDatabase != null && hashFromDatabase == hash;
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