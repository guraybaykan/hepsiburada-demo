using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Service.NofiticationHandlers
{
    public class OrderCreatedNofiticationHandler : INotificationHandler<OrderCreatedNotification>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public OrderCreatedNofiticationHandler(ICampaignRepository campaignRepository, 
            IMediator mediator,
            IProductRepository productRepository)
        {
            _campaignRepository = campaignRepository;
            _mediator = mediator;
            _productRepository = productRepository;
        }
        public async Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            var campaign = await _campaignRepository.Get(notification.CampaignName, cancellationToken);
            RecalculateCampaignData(ref campaign, notification);
            await _campaignRepository.Update(campaign, cancellationToken);

            var product = await _productRepository.Get(campaign.Product.Code, cancellationToken);
            product.Stock -= notification.Quantity;
            await _productRepository.Update(product, cancellationToken);

            if(campaign.TargetSalesCount <= campaign.TotalSalesCount)
            {
                await _mediator.Publish(new CampaignFinishedNotification
                {
                    CampaignName = campaign.Name
                });
            }
        }

        private void RecalculateCampaignData(ref Campaign campaign, OrderCreatedNotification notification)
        {
            var turnover = notification.Price * notification.Quantity;
            var totalSales = campaign.TotalSalesCount + notification.Quantity;
            campaign.AverageItemPrice = turnover / totalSales;
            campaign.TotalSalesCount = totalSales;
            campaign.Turnover = turnover; 
        }
    }
}
