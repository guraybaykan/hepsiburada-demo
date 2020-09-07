using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.NofiticationHandlers
{
    public class TimeIncreasedNotificationHandler : INotificationHandler<TimeIncreasedNotification>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICampaignRepository _campaignRepository;

        public TimeIncreasedNotificationHandler(IProductRepository productRepository,
            ICampaignRepository campaignRepository)
        {
            _productRepository = productRepository;
            _campaignRepository = campaignRepository;
        }
        public async Task Handle(TimeIncreasedNotification notification, CancellationToken cancellationToken)
        {
            var campaigns = await _campaignRepository.GetActiveFlaggedCampaigns(cancellationToken);
            List<Task> tasks = new List<Task>();
            foreach (var campaign in campaigns)
            {
                var product = campaign.Product;

                // if campaign has finished
                if (campaign.StartDate.AddHours(campaign.DurationInHour) <= notification.Now)
                {
                    campaign.IsActive = false;
                    tasks.Add(_campaignRepository.Update(campaign, cancellationToken));

                    product.Price = campaign.StartPrice;
                    tasks.Add(_productRepository.Update(product, cancellationToken));
                }
                else
                {
                    product.Price = campaign.StartPrice -
                        campaign.StartPrice *
                        ((decimal)(notification.Now - campaign.StartDate).Hours / campaign.DurationInHour) *
                        (campaign.Limit / 100);
                    
                    tasks.Add(_productRepository.Update(product, cancellationToken));
                }
            }

            await Task.WhenAll(tasks);
        }

    }
}