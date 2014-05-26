using Data.Repositories;
using Domain.AbstractRepositories;
using Domain.Users.Factories;
using Domain.Users.Services;
using StructureMap.Configuration.DSL;

namespace Infrastructure.IoC
{
    public class DomainRegistry: Registry
    {
        public DomainRegistry()
        {
            For<ICardRepository>().Use<CardRepository>();
            For<IDeckRepository>().Use<DeckRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<IAuthenticationRepository>().Use<AuthenticationRepository>();

            For<IAuthenticationService>().Use<AuthenticationService>();

            For<IUserFactory>().Use<UserFactory>();
        }
    }
}
