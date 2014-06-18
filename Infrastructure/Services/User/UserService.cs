using System;
using System.Linq;
using Domain.AbstractRepositories;
using Domain.Users;
using Infrastructure.Dto.Card;
using Infrastructure.Dto.Deck;
using Infrastructure.Dto.User;

namespace Infrastructure.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserInfoResponse Info(UserInfoRequest request)
        {
            var user = _userRepository.Get(request.Id);

            var userDto = new UserDto
            {
                Id = user.Id,
                IsAdmin = user.IsInRole(Role.Admin),
                Name = user.Name,
                Cards = user.Cards.Select(c => new CardDto
                {
                    Artist = c.Artist,
                    Colors = c.Colors,
                    ConvertedManaCost = c.ConvertedManaCost,
                    Description = c.Description,
                    Flavor = c.Flavor,
                    Formats = c.Formats.Select(f => new FormatDto
                    {
                        Legality = f.Legality,
                        Name = f.Name
                    }),
                    Id = c.Id,
                    Loyalty = c.Loyalty,
                    ManaCost = c.ManaCost,
                    Name = c.Name,
                    Power = c.Power,
                    Rarity = c.Rarity,
                    //ReleaseDate = c.ReleaseDate,
                    Rulings = c.Rulings.Select(r => new RulingDto
                    {
                        ReleasedAt = r.ReleasedAt,
                        Rule = r.Rule
                    }),
                    SearchName = c.SearchName,
                    SetId = c.SetId,
                    SetNumber = c.SetNumber,
                    SubType = c.SubType,
                    Toughness = c.Toughness,
                    Type = c.Type
                }),
            Decks = user.Decks.Select(d => new DeckDto
            {
                Name = d.Name,
                Cards = d.Cards.Select(c => new CardDto
                {
                    Artist = c.Artist,
                    Colors = c.Colors,
                    ConvertedManaCost = c.ConvertedManaCost,
                    Description = c.Description,
                    Flavor = c.Flavor,
                    Formats = c.Formats.Select(f => new FormatDto
                    {
                        Legality = f.Legality,
                        Name = f.Name
                    }),
                    Id = c.Id,
                    Loyalty = c.Loyalty,
                    ManaCost = c.ManaCost,
                    Name = c.Name,
                    Power = c.Power,
                    Rarity = c.Rarity,
                    ReleasedAt = c.ReleaseDate,
                    Rulings = c.Rulings.Select(r => new RulingDto
                    {
                        ReleasedAt = r.ReleasedAt,
                        Rule = r.Rule
                    }),
                    SearchName = c.SearchName,
                    SetId = c.SetId,
                    SetNumber = c.SetNumber,
                    SubType = c.SubType,
                    Toughness = c.Toughness,
                    Type = c.Type
                })
            })
            };
            return new UserInfoResponse {User = userDto};
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
