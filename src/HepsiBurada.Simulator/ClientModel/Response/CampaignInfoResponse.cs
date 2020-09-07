namespace HepsiBurada.Simulator.ClientModel.Response
{
    public class CampaignInfoResponse
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int DurationInHour { get; set; }
        public decimal Limit { get; set; }
        public int TargetSalesCount { get; set; }
        public decimal Turnover { get; set; }
        public int TotalSalesCount { get; set; }
        public decimal AverageItemPrice { get; set; }
        public bool Active { get; set; }
    }
}