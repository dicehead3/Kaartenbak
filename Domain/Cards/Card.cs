using System;
using System.Collections.Generic;
using Domain.BaseObjects;
using Utilities.ExtensionMethods;

namespace Domain.Cards
{
    public class Card : Entity
    {
        private readonly int _multiverseId;
        private readonly int _setNumber;
        private string _name;
        private readonly IEnumerable<string> _colors = new List<string>();
        private string _manaCost;
        private readonly int _convertedManaCost;
        private string _type;
        private readonly Rarity _rarity;
        private readonly int _setId;
        private readonly IEnumerable<Ruling> _rulings = new List<Ruling>(); 
        private readonly IEnumerable<Format> _formats = new List<Format>();

        public Card(int multiverseId, int setNumber, string name, string manaCost, int convertedManaCost, string type, Rarity rarity,
            int setId)
        {
            _multiverseId = multiverseId;
            _setNumber = setNumber;
            Name = name;
            ManaCost = manaCost;
            _convertedManaCost = convertedManaCost;
            Type = type;
            _rarity = rarity;
            _setId = setId;
        }

        protected Card()
        {
        }

        public virtual int MultiverseId
        {
            get { return _multiverseId; }
        }

        public virtual int RelatedCardId { get; set; }

        public virtual int SetNumber
        {
            get { return _setNumber; }
        }

        public virtual string Name
        {
            get { return _name; }
            protected set { _name = value.Required("Each card does have a name"); }
        }

        public virtual string SearchName { get; set; }

        public virtual string Description { get; set; }

        public virtual string Flavor { get; set; }

        public virtual IEnumerable<string> Colors
        {
            get { return _colors; }
        }

        public virtual string ManaCost
        {
            get { return _manaCost; }
            set { _manaCost = value.Required("Manacost is required."); }
        }

        public virtual int ConvertedManaCost
        {
            get { return _convertedManaCost; }
        }

        public virtual string SetName { get; set; }
        
        public virtual string Type
        {
            get { return _type; }
            set { _type = value.Required("Card type is required"); }
        }

        public virtual string SubType { get; set; }

        public virtual int Power { get; set; }

        public virtual int Toughness { get; set; }

        public virtual int Loyalty { get; set; }

        public virtual Rarity Rarity
        {
            get { return _rarity; }
        }

        public virtual string Artist { get; set; }

        public virtual int SetId
        {
            get { return _setId; }
        }

        public virtual bool IsToken { get; set; }

        public virtual bool IsPromo { get; set; }

        public virtual IEnumerable<Ruling> Rulings
        {
            get { return _rulings; }
        }

        public virtual IEnumerable<Format> Formats
        {
            get { return _formats; }
        } 

        public virtual DateTime ReleaseDate { get; set; }
    }
}