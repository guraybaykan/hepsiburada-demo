using System;

namespace HepsiBurada.Core.Model
{
    public class Campaign
    {
        public virtual string Name { get; set; }
        public virtual Product Product { get; set; }
        public virtual int DurationInHour { get; set; }
        public virtual decimal Limit { get; set; }
        public virtual int TargetSales { get; set; }
        public virtual int TotalSales { get; set; }
        public virtual decimal Turnover {get;set;}
        public virtual decimal AverageItemPrice {get; set;}
        public virtual DateTime StartDate { get; set; }
    }
}
