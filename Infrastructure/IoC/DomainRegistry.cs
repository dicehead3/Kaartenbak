using Data.Repositories;
using Domain.AbstractRepositories;
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
        }
    }
}
