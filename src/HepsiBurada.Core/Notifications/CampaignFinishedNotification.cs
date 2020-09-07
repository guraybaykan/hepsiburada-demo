using MediatR;

namespace HepsiBurada.Core.Notifications
{
    public class CampaignFinishedNotification : INotification
    {
        public string CampaignName { get; set; }
    }
}