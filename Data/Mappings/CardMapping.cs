using Domain.Cards;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;

namespace Data.Mappings
{
    public class CardMapping: ClassMap<Card>
    {
        public CardMapping()
        {
            Table("Cards");
            Id(x => x.Id);
            Map(x => x.MultiverseId)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
            Map(x => x.RelatedCardId);
            Map(x => x.SetNumber)
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Name)
                .Not.Nullable()
                .Access.CamelCaseField(Prefix.Underscore)
                .Length(9999);
            Map(x => x.SearchName).Length(9999);
            Map(x => x.Description).Length(9999);
            Map(x => x.Flavor).Length(9999);
            HasMany(x => x.Colors)
                .AsBag().Cascade.None()
                .Element("Color")
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.ManaCost)
                .Not.Nullable()
                .Length(9999)
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.ConvertedManaCost)
                .Not.Nullable()
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.SetName).Length(9999);
            Map(x => x.Type)
                .Length(9999)
                .Not.Nullable()
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.SubType).Length(9999);
            Map(x => x.Power);
            Map(x => x.Toughness);
            Map(x => x.Loyalty);
            Map(x => x.Rarity)
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Artist).Length(9999);
            Map(x => x.SetId)
                .Not.Nullable();
            Map(x => x.IsToken);
            Map(x => x.IsPromo);

            HasMany(x => x.Rulings)
                .Table("Rulings")
                //.Element("Id")
                .AsSet()
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.LazyLoad();

            HasMany(x => x.Formats)
                .Table("Formats")
                //.Element("Id")
                .AsSet()
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.LazyLoad();

            Map(x => x.ReleaseDate);
        }
    }
}
