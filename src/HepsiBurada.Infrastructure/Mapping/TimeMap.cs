using System;
using FluentNHibernate.Mapping;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Infrastructure.Mapping
{
    public class TimeMap : ClassMap<Time>
    {
        public TimeMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.TimeStamp);
        }
    }
}
