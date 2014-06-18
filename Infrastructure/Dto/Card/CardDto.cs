using System;
using System.Collections.Generic;
using Domain.Cards;

namespace Infrastructure.Dto.Card
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SetNumber { get; set; }
        public string SearchName { get; set; }
        public string Description { get; set; }
        public string Flavor { get; set; }
        public IEnumerable<string> Colors { get; set; }
        public string ManaCost { get; set; }
        public int ConvertedManaCost { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public int Power { get; set; }
        public int Toughness { get; set; }
        public int Loyalty { get; set; }
        public Rarity Rarity { get; set; }
        public string Artist { get; set; }
        public DateTime ReleasedAt { get; set; }

        public IEnumerable<RulingDto> Rulings { get; set; }
        public IEnumerable<FormatDto> Formats { get; set; } 

        public int SetId { get; set; }
    }
}
