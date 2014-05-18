using Domain.Cards;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class FormatMapping: ClassMap<Format>
    {
        public FormatMapping()
        {
            Table("Formats");
            Id(x => x.Id);
            Map(x => x.Name)
                .Not.Nullable()
                .Access.CamelCaseField(Prefix.Underscore)
                .Length(9999);
            Map(x => x.Legality)
                .Not.Nullable()
                .Access.CamelCaseField(Prefix.Underscore)
                .Length(9999);
        }
    }
}
