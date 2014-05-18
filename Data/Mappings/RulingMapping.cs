using Domain.Cards;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class RulingMapping: ClassMap<Ruling>
    {
        public RulingMapping()
        {
            Table("Rulings");
            Id(x => x.Id);
            Map(x => x.ReleasedAt)
                .Not.Nullable()
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Rule)
                .Not.Nullable()
                .Length(9999)
                .Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
