namespace HepsiBurada.Core.Model
{
    public class Campaign
    {
        public virtual string Name { get; set; }
        public virtual Product Product { get; set; }
        public virtual int DurationInHour { get; set; }
        public virtual decimal Limit { get; set; }
        public virtual int TargetSalesCount { get; set; }
    }
}
