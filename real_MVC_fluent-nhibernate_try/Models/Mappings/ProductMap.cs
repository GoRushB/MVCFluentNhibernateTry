using FluentNHibernate.Mapping;

namespace real_MVC_fluent_nhibernate_try.Models.Mappings
{   
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.ProductId).GeneratedBy.Identity();
            Map(x => x.Price);
            Map(x => x.Name);
            Map(x => x.ProductArtUrl);
            HasManyToMany(x => x.Stores).Cascade.All().Inverse().Table("StoreProduct");
        }
    }
}