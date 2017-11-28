using FluentNHibernate.Mapping;

namespace real_MVC_fluent_nhibernate_try.Models.Mappings
{
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.StoreId).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.StoreArtUrl);
            HasMany(x => x.Employees).Inverse().Cascade.All();
            HasManyToMany(x => x.Products).Cascade.All().Table("StoreProduct");
        }
    }
}