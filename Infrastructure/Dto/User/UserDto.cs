using System.Collections.Generic;
using Infrastructure.Dto.Card;
using Infrastructure.Dto.Deck;

namespace Infrastructure.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<CardDto> Cards { get; set; }
        public IEnumerable<DeckDto> Decks { get; set; } 
    }
}
