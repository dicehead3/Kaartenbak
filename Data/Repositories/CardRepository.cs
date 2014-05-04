using System;
using Domain.AbstractRepositories;
using Domain.Cards;
using NHibernate;

namespace Data.Repositories
{
    public class CardRepository: BaseRepository<Card>, ICardRepository
    {
        private readonly ISession _session;

        public CardRepository(ISession session)
        {
            _session = session;
        }

        public override ISession Session
        {
            get { return _session; }
        }

        public override void Save(Card card)
        {
            if (!card.ExistsInDatabase())
            {
                throw new InvalidOperationException("Card is not yet created, can't save.");
            }

            base.Save(card);
        }
    }
}
