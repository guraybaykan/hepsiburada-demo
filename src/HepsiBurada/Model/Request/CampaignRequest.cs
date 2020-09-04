namespace HepsiBurada.Model.Request
{
    public class CampaignRequest
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int DurationInHour { get; set; }
        public decimal Limit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}