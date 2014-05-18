using Domain.Users;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class UserMapping: ClassMap<User>
    {
        public UserMapping()
        {
            Table("Users");
            Id(x => x.Id);
            HasManyToMany(x => x.Cards)
                .AsBag().Cascade.None()
                .Access.CamelCaseField(Prefix.Underscore);
            HasManyToMany(x => x.Decks)
                .AsBag().Cascade.AllDeleteOrphan()
                .Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Name)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Length(9999);
            Map(x => x.Email)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Length(200);
            
            HasMany(x => x.Roles)
                .Table("Roles")
                .Element("Id")
                .AsSet()
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.LazyLoad();
            
            Map(x => x.Created);
            Map(x => x.Modified);
        }
    }
}
