namespace HepsiBurada.Simulator.Request
{
    public class CampaignRequest
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int DurationInHour { get; set; }
        public decimal Limit { get; set; }
        public int TargetSalesCount { get; set; }
        public decimal Turnover { get; set; }
        public int TotalSales { get; set; }
        public decimal AverageItemPrice { get; set; }
        public bool Active { get; set; }
    }
}