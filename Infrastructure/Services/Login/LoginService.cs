using System.Collections.Generic;
using System.Linq;
using Domain.Cards;
using Domain.Users;
using Domain.Users.Services;
using Infrastructure.Dto.Card;
using Infrastructure.Dto.Deck;
using Infrastructure.Dto.User;

namespace Infrastructure.Services.Login
{
    public class LoginService: ILoginService
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public LoginResponse Login(LoginRequest request)
        {
            return new LoginResponse();
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            var registerUserRequest = new RegisterUserRequest()
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                Username = request.Username
            };

            var user = _authenticationService.RegisterUser(registerUserRequest);

            return new RegisterResponse
            {
                Success = true,
                User = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Cards = ConvertToCardDtos(user.Cards),
                    Decks = user.Decks.Select(d => new DeckDto
                    {
                        Name = d.Name,
                        Cards = ConvertToCardDtos(d.Cards)
                    }),
                    IsAdmin = user.IsInRole(Role.Admin)
                }
            };
        }

        private IEnumerable<CardDto> ConvertToCardDtos(IEnumerable<Card> cards)
        {
            return cards.Select(x => new CardDto
            {
                Artist = x.Artist,
                Name = x.Name,
                Id = x.Id,
                Colors = x.Colors,
                ConvertedManaCost = x.ConvertedManaCost,
                Description = x.Description,
                Flavor = x.Flavor,
                Formats = x.Formats.Select(f => new FormatDto
                {
                    Legality = f.Legality,
                    Name = f.Name
                }),
                Loyalty = x.Loyalty,
                ManaCost = x.ManaCost,
                Power = x.Power,
                Rarity = x.Rarity,
                ReleasedAt = x.ReleaseDate,
                Rulings = x.Rulings.Select(r => new RulingDto
                {
                    ReleasedAt = r.ReleasedAt,
                    Rule = r.Rule
                }),
                SearchName = x.SearchName,
                SetId = x.SetId,
                SetNumber = x.SetNumber,
                SubType = x.SubType,
                Toughness = x.Toughness,
                Type = x.Type
            });
        }
    }
}
