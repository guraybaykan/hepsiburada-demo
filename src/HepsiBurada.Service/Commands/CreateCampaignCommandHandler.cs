using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Campaign>
    {
        private readonly IMapper _mapper;

        private readonly ICampaignRepository _campaignRepository; 
        public CreateCampaignCommandHandler(IMapper mapper,
                    ICampaignRepository campaignRepository)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
        }
        public async Task<Campaign> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            //todo is it necessary to control. Name is ID actually
            if(await _campaignRepository.Get(request.Name, cancellationToken) != null)
            {
                throw new System.Exception("The campaign is already defined");
            }

            var campaign = _mapper.Map<Campaign>(request);

            campaign.AverageItemPrice = 0;
            campaign.TotalSales = 0;
            campaign.Turnover = 0;
            campaign.StartDate = DateTime.Now;

            campaign.Name = await _campaignRepository.Save(campaign, cancellationToken);
            
            return campaign;
        }
    }
}
