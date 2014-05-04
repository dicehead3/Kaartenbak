using System.Collections.Generic;
using System.Linq;
using Domain.BaseObjects;
using Utilities.ExtensionMethods;

namespace Domain.Cards
{
    public class Deck: Entity
    {
        private string _name;
        private readonly IList<Card> _cards = new List<Card>();

        public Deck(string name)
        {
            Name = name;
        }

        protected Deck()
        {
        }

        public virtual string Name
        {
            get { return _name; }
            protected set { _name = value.Required("A deck needs a name"); }
        }

        public virtual IList<Card> Cards
        {
            get { return _cards; }
        } 
    }
}
