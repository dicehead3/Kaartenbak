using System;
using Domain.BaseObjects;
using Utilities.ExtensionMethods;

namespace Domain.Cards
{
    public class Ruling: Entity
    {
        private DateTime _releasedAt;
        private string _rule;

        public Ruling(DateTime releasedAt, string rule)
        {
            ReleasedAt = releasedAt;
            Rule = rule;
        }

        public virtual DateTime ReleasedAt
        {
            get { return _releasedAt; }
            protected set { _releasedAt = value; }
        }

        public virtual string Rule
        {
            get { return _rule; }
            set { _rule = value.Required(); }
        }
    }
}
