using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Domain.AbstractRepositories;
using Domain.BaseObjects;
using Domain.Cards;
using Utilities.Exceptions;
using Utilities.ExtensionMethods;

namespace Domain.Users
{
    public class User: Entity, IPrincipal
    {
        private string _name;
        private string _email;
        private IIdentity _identity;
        private readonly ICollection<Role> _roles = new HashSet<Role>();
        private readonly IList<Card> _cards = new List<Card>();
        private readonly IList<Deck> _decks = new List<Deck>(); 

        public User(string email, string name, IUserRepository repository)
        {
            Name = name;
            CheckEmail(email, repository);
        }

        protected User() { }
        
        public virtual string Name
        {
            get { return _name; }
            set { _name = value.Required("Displayname is required"); }
        }
        
        public virtual string Email
        {
            get { return _email; }
        }
        
        public virtual IIdentity Identity
        {
            get { return _identity ?? (_identity = new ClaimsIdentity(Email)); }
        }

        public virtual IEnumerable<Role> Roles
        {
            get { return _roles; }
        }

        public virtual IEnumerable<Card> Cards
        {
            get { return _cards; }
        }

        public virtual IEnumerable<Deck> Decks
        {
            get { return _decks; }
        } 
        
        public virtual bool IsInRole(string role)
        {
            return IsInRole((Role) Enum.Parse(typeof (Role), role, true));
        }

        public virtual bool IsInRole(Role role)
        {
            return _roles.Contains(role);
        }

        private void CheckEmail(string email, IUserRepository repository)
        {
            var emailAddress = email.Required("Email is required").ValidEmailAddress();
            if (!repository.EmailExists(emailAddress))
            {
                _email = emailAddress;
            }
            else
            {
                throw new Baka("Email already in use");
            }
        }
    }
}
