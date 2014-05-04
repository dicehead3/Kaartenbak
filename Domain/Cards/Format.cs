using Domain.BaseObjects;
using Utilities.ExtensionMethods;

namespace Domain.Cards
{
    public class Format: Entity
    {
        private string _name;
        private string _legality;

        public Format(string name, string legality)
        {
            Name = name;
            Legality = legality;
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value.Required(); }
        }

        public virtual string Legality
        {
            get { return _legality; }
            set { _legality = value.Required(); }
        }
    }
}
