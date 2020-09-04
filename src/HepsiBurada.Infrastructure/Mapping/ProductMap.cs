using FluentNHibernate.Mapping;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Infrastructure.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            Map(x => x.Price);
            Map(x => x.Stock);
            HasOne(x => x.Campaign).LazyLoad();
        }
    }
}
