using MediatR;

namespace HepsiBurada.Core.Notifications
{
    public class OrderCreatedNotification : INotification
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CampaignName { get; set; }
    }
}