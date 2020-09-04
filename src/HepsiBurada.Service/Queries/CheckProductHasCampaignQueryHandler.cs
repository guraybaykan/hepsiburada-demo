using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class CheckProductHasCampaignQueryHandler : IRequestHandler<CheckProductHasCampaignQuery, Campaign>
    {
        private readonly ICampaignRepository _campaignRepository;

        public CheckProductHasCampaignQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<Campaign> Handle(CheckProductHasCampaignQuery request, CancellationToken cancellationToken)
        {
            return await _campaignRepository.CheckActiveCampaign(request.ProductCode, request.Date, cancellationToken);
        }
    }
}