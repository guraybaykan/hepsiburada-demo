using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.NofiticationHandlers
{
    public class CampaingFinishedNotificationHandler : INotificationHandler<CampaignFinishedNotification>
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaingFinishedNotificationHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task Handle(CampaignFinishedNotification notification, CancellationToken cancellationToken)
        {
            var campaign = await _campaignRepository.Get(notification.CampaignName, cancellationToken);
            campaign.IsActive = false;
            await _campaignRepository.Update(campaign, cancellationToken);
        }
    }
}