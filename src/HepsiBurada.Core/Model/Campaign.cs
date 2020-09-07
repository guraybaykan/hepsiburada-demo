using System;

namespace HepsiBurada.Core.Model
{
    public class Campaign
    {
        public virtual string Name { get; set; }
        public virtual Product Product { get; set; }
        public virtual int DurationInHour { get; set; }
        public virtual decimal Limit { get; set; }
        public virtual int TargetSalesCount { get; set; }
        public virtual int TotalSalesCount { get; set; }
        public virtual decimal Turnover {get;set;}
        public virtual decimal AverageItemPrice {get; set;}
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual decimal StartPrice { get; set; }
    }
}
