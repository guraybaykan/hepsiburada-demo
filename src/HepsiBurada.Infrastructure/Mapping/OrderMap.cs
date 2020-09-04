using FluentNHibernate.Mapping;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Infrastructure.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            Map(x => x.CreatedAt);
            HasOne(x => x.Product).LazyLoad();
            HasOne(x => x.Campaign).LazyLoad();
        }
    }
}
