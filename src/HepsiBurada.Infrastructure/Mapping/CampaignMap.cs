using System;
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
            Map(x => x.TargetSalesCount);
            References<Product>(x => x.Product).LazyLoad();
        }
    }
}
