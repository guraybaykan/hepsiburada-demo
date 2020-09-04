using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Businness
{
    public class CampaignService : ICampaignService, IService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        public CampaignService(ICampaignRepository campaignRepository,
            IProductRepository productRepository,
            IMediator meediator)
        {
            _campaignRepository = campaignRepository;
            _mediator = meediator;
        }
        public async Task<Campaign> CreateCampaign(Campaign campaign, CancellationToken cancellationToken)
        {
             //todo is it necessary to control. Name is ID actually
            if(await _campaignRepository.Get(campaign.Name, cancellationToken) != null)
            {
                throw new System.Exception("The campaign is already defined");
            }
            campaign.Name = await _campaignRepository.Save(campaign, cancellationToken);
            
            return campaign;
        }

        public async Task<Campaign> GetCampaign(string name, CancellationToken cancellationToken)
        {
            return await _campaignRepository.Get(name, cancellationToken);
        }
    }
}
