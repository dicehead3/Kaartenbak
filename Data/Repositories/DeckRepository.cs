using System;
using Domain.AbstractRepositories;
using Domain.Cards;
using NHibernate;

namespace Data.Repositories
{
    public class DeckRepository: BaseRepository<Deck>, IDeckRepository
    {
        private readonly ISession _session;

        public DeckRepository(ISession session)
        {
            _session = session;
        }

        public override ISession Session
        {
            get { return _session; }
        }

        public override void Save(Deck deck)
        {
            if (!deck.ExistsInDatabase())
            {
                throw new InvalidOperationException("Create deck before saving it");
            }
            base.Save(deck);
        }
    }
}
