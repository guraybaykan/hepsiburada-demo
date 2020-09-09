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
        private readonly IProductRepository _productRepository;

        public CampaingFinishedNotificationHandler(ICampaignRepository campaignRepository,
            IProductRepository productRepository)
        {
            _campaignRepository = campaignRepository;
            _productRepository = productRepository;
        }
        public async Task Handle(CampaignFinishedNotification notification, CancellationToken cancellationToken)
        {
            var campaign = await _campaignRepository.Get(notification.CampaignName, cancellationToken);
            campaign.IsActive = false;
            campaign.Product.Price = campaign.StartPrice;
            await _campaignRepository.Update(campaign, cancellationToken);
        }
    }
}