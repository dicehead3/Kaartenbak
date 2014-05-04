using System.Collections.Generic;
using Infrastructure.Dto.Card;

namespace Infrastructure.Dto.Deck
{
    public class DeckDto
    {
        public string Name { get; set; }
        public IEnumerable<CardDto> Cards { get; set; }
    }
}
