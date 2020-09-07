using FluentNHibernate.Mapping;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Infrastructure.Mapping
{
    public class CampaignMap : ClassMap<Campaign>
    {
        public CampaignMap()
        {
            Id(x => x.Name).GeneratedBy.Assigned();
            Map(x => x.DurationInHour);
            Map(x => x.Limit, "`Limit`");
            Map(x => x.TotalSales);
            Map(x => x.TargetSales);
            Map(x => x.Turnover);
            Map(x => x.AverageItemPrice);
            Map(x => x.StartDate);
            Map(x => x.EndDate);
            Map(x => x.IsActive);
            Map(x => x.StartPrice);
            References<Product>(x => x.Product).LazyLoad();
        }
    }
}
